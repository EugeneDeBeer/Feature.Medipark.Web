node {
  try
  {
      //Checkout code from repository
      checkout scm
      //Grant access to the current directory
      sh("chmod -R ugo+rw ${WORKSPACE}")              
  
      /****************************************************************************************
      /                               Edit the section below                                   /
      /****************************************************************************************/
      def appName = 'feature-ohs-web'
	  def projectFolder = 'Feature.OHS.Web' 
      def testFolder = 'Feature.OHS.Web.Test'
      def platform = 'appengine'
      /****************************************************************************************/
      //Database instances
      def devDB = "medipark-hospital:europe-west1:omeya-dev"
      def qaDB = "medipark-hospital:us-east1:omeyah-db"
      def uatDB = "medipark-hospital:europe-west1:omeya-uat"
      def prodDB = (appName.startsWith('omeya')) ? 'medipark-hospital-prod:europe-west1:mvp-ods' : 'medipark-hospital-prod:europe-west1:mvp-caches'
      def dll = "${projectFolder}'.dll'"   
      def project = (env.BRANCH_NAME != 'prod') ? 'medipark-hospital' : 'medipark-hospital-prod'  
      
      //Login to gcloud and update SDK
       stage ('Login to Gcloud') {
         if (project == 'medipark-hospital'){
                  configFileProvider([configFile(fileId: '1327642d-3075-4861-8d33-9558fe199e31', variable: 'GCLOUD_AUTH')]) {
                 sh("gcloud auth activate-service-account --key-file $GCLOUD_AUTH")
                 sh("gcloud auth login medipark-hospital@appspot.gserviceaccount.com") 
                  }
             }
              sh("gcloud components update")
			  sh("gcloud auth configure-docker")
        }
      
       
         
      
            def imageTag = "eu.gcr.io/${project}/appengine/${appName[0]}/${env.BRANCH_NAME}/${env.BRANCH_NAME}:${env.BUILD_NUMBER}"  
            /****************************************************************************************
            /                        Use this section when building AppEngine service                /
            /****************************************************************************************/
            
            stage ('Build AppEngine image') {   
                    //Copy cloudproxy file
                 //   if (project == 'harambee-dev'){
                    //    sh("gsutil cp gs://medipark-hospital-code/cloudsqlproxy.linux.amd64 .")
                //    }
                //    else{
                     //   sh("gsutil cp gs://medipark-hospital-secrets/cloudsqlproxy.linux.amd64 .")
                //    }
                    switch (env.BRANCH_NAME){
                        case "dev":
                            sh("docker build --build-arg folder=${projectFolder} --build-arg testfolder=${testFolder} --build-arg db=${devDB} -t ${imageTag} --file=Dockerfile_AE .")
                            break
                        case "qa":
                            sh("docker build --build-arg folder=${projectFolder} --build-arg testfolder=${testFolder} --build-arg db=${qaDB} -t ${imageTag} --file=Dockerfile_AE .")
                            break
                        case "uat":
                            sh("docker build --build-arg folder=${projectFolder} --build-arg testfolder=${testFolder} --build-arg db=${uatDB} -t ${imageTag} --file=Dockerfile_AE .")
                            break
                        case "prod":
                            sh("docker build --build-arg folder=${projectFolder} --build-arg testfolder=${testFolder} --build-arg db=${prodDB} -t ${imageTag} --file=Dockerfile_AE .")
                            break
                    }
                    sh("gcloud docker -- push ${imageTag}")   
            }                   
            stage ('Deploy to AppEngine'){      
                   // for (i = 0; i < appName.length; i++){
                        //Overwrite the app.yaml file with one that is in Jenkins managed files
                        configFileProvider(
                            [configFile(fileId: 'app_yaml', variable: 'DEPLOY')]){
                            sh("yes | cp -rf $DEPLOY ./app.yaml")
                        }
                        //def tenantID = i + 1
                        sh("sed -i.bak 's#REPLACE_TENANT#${tenant}#' app.yaml")
                        sh("sed -i.bak 's#REPLACE_ID#${1}#' app.yaml")
                        switch (env.BRANCH_NAME) {
                            case "dev":   
                                sh("sed -i.bak 's#service:#service: dev-${appName}#' app.yaml")    
							//     sh("gcloud app deploy --image-url ${imageTag} --version v${env.BUILD_NUMBER}")
							
			                    break        
                            case "qa":
                                sh("sed -i.bak 's#service:#service: qa-${appName}#' app.yaml")
								//sh("gcloud app deploy --image-url ${imageTag} --version v${env.BUILD_NUMBER} --stop-previous-version")
				             
                                break
                            case "uat":   
                                sh("sed -i.bak 's#service:#service: uat-${appName}#' app.yaml")
							   // sh("gcloud app deploy --image-url ${imageTag} --version v${env.BUILD_NUMBER} --stop-previous-version")
			                   
				break
                            case "prod":
                                sh("sed -i.bak 's#service:#service: ${appName}#' app.yaml")
							  //  sh("gcloud app deploy --image-url ${imageTag} --version v${env.BUILD_NUMBER} --stop-previous-version")
			                 
				break   
                        }

                        configFileProvider(
                            [configFile(fileId: 'app_yaml', variable: 'DEPLOY')]){
                            sh("yes | cp -rf $DEPLOY ./app.yaml")
                        }
						
                    }                   
                       
            //END DEPLOY TO APPENGINE
      }   
  //}
  catch(e){
        currentBuild.result = "FAILED"
        throw e
  }
  finally{
        // Success or failure, always send notifications
        notifyBuild(currentBuild.result)
  }
}
def notifyBuild(String buildStatus) {
  // build status of null means successful
  buildStatus =  buildStatus ?: 'SUCCESSFUL'
  // Default values
  def colorName = 'RED'
  def colorCode = '#FF0000'
  def commiter =  sh (
        script: 'git show -s --pretty=%an',
        returnStdout: true).trim()
  def subject = "${commiter}: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]' failed"
  def summary = "${subject} (${env.BUILD_URL})"  
  // Send notification to slack on anything but success
  if (buildStatus != 'SUCCESSFUL') {        
    //slackSend (color: colorCode, message: summary)
  }  
  // Below used for starting automated test on 
  /*
  else {
        //launch automation build for mobi
        withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'jenkins-auto', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']]) {
            sh("curl -X POST --user $USERNAME:$PASSWORD -H \$(curl --user $USERNAME:$PASSWORD http://35.187.70.91:8080/crumbIssuer/api/xml?xpath=concat\\(//crumbRequestField,%22:%22,//crumb\\)) 'http://35.187.70.91:8080/job/test/buildWithParameters?TOKEN=xB5AZrMeX9jMD5KT2n3r&REPO=TestJenkins&BRANCH=${env.BRANCH_NAME}'")
      }
  } 
  */
}
