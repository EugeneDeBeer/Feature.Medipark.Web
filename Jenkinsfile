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
          //  configFileProvider([configFile(fileId: '2ac32ad9-417d-4c69-8b5c-dbfc2ea71c8c', variable: 'GCLOUD_AUTH')]) {
                sh("gcloud auth activate-service-account --key-file $GCLOUD_AUTH")
                sh("gcloud auth login medipark-hospital@appspot.gserviceaccount.com") 
               // if (platform == 'appengine'){
                //    sh("gsutil cp gs://medipark-hospital-dev-secrets/cloudsqlserviceaccount.json .")
              //  }
            }
            //Overwrite the appsettings.json file with one that is in Google cloud storage
           // sh("gsutil cp gs://medipark-hospital-dev-secrets/appsettings/${env.BRANCH_NAME}_appsettings.json ./${projectFolder}/appsettings.json")
        }
        else{           
            configFileProvider([configFile(fileId: 'harambee_sa', variable: 'GCLOUD_AUTH')]) {              
                sh("gcloud auth activate-service-account --key-file $GCLOUD_AUTH")
                sh("gcloud config set project ${project}")
                sh("gcloud auth login medipark-hospital-prod.iam.gserviceaccount.com")
                if (platform == 'appengine'){
               //     sh("gsutil cp gs://medipark-hospital-prod/cloudsqlserviceaccount.json .")
                }
            }
            //Overwrite the appsettings.json file with one that is in Google cloud storage
           // sh("gsutil cp gs://medipark-hospital/appsettings.json ./${projectFolder}/appsettings.json")
        }     
        //Update gcloud to meet minimum version
        sh("gcloud components update")
      }   
      
      if (platform == "kubernetes"){          
            /****************************************************************************************
            /                               Use this section when building k8s service               /
            /****************************************************************************************/  
            def imageTag = "eu.gcr.io/${project}/k8s/${appName}/${env.BRANCH_NAME}:${env.BUILD_NUMBER}"    
            stage ('Build k8s image') { 
                    //Overwrite the Dockerfile with one that is in Jenkins managed files
                    configFileProvider([configFile(fileId: 'Dockerfile2', variable: 'DOCKER')]){
                        sh("yes | cp -rf $DOCKER ./Dockerfile")
                    }  
                    sh("docker build --build-arg folder=${projectFolder} --build-arg testfolder=${testFolder} --build-arg dll=${dll} -t ${imageTag} .")
                    sh("gcloud docker -- push ${imageTag}")   
            }
            stage ('Deploy to k8s') {
                    //Overwrite the deploy.yml file with one that is in Jenkins managed files
                    configFileProvider(
                        [configFile(fileId: 'deployment_file', variable: 'DEPLOY')]){
                        sh("yes | cp -rf $DEPLOY ./deploy.yml")
                    }
                    
                    sh("sed -i.bak 's#appName#${appName}#' deploy.yml")   
                    sh("sed -i.bak 's#imageTag#${imageTag}#' deploy.yml")         
                    switch (env.BRANCH_NAME) {
                        case "development":                   
                            sh("gcloud container clusters get-credentials mvp-dev-cluster --zone europe-west1-d --project ${project}")
                            sh("sed -i.bak 's#instanceName#${devDB}#' deploy.yml")
                            break        
                        case "qa":
                            sh("gcloud container clusters get-credentials mvp-qa-cluster --zone europe-west1-d --project ${project}")
                            sh("sed -i.bak 's#instanceName#${qaDB}#' deploy.yml")
                            break
                        case "uat":
                            sh("gcloud container clusters get-credentials mvp-uat-cluster --zone europe-west1-d --project ${project}")
                            sh("sed -i.bak 's#instanceName#${uatDB}#' deploy.yml")
                            break
                        case "prod":
                            sh("gcloud container clusters get-credentials harambee --zone europe-west1-d --project ${project}")
                            sh("sed -i.bak 's#instanceName#${prodDB}#' deploy.yml")                   
                            break                   
                    }                           
                    //Check if deployment exists
                    def depExists = sh (
                        script: "kubectl get deployment ${appName} --namespace=default --ignore-not-found",
                    returnStdout: true).trim()
                
                    if (depExists != ""){
                        sh("kubectl delete --namespace=default -f deploy.yml --ignore-not-found=true")
                    }
                    sh("kubectl create --namespace=default -f deploy.yml --record")
            }
      }
      else{
            def imageTag = "eu.gcr.io/${project}/appengine/${appName[0]}/${env.BRANCH_NAME}/${env.BRANCH_NAME}:${env.BUILD_NUMBER}"  
            /****************************************************************************************
            /                        Use this section when building AppEngine service                /
            /****************************************************************************************/
            
            stage ('Build AppEngine image') {   
                    //Copy cloudproxy file
                    if (project == 'harambee-dev'){
                    //    sh("gsutil cp gs://medipark-hospital-code/cloudsqlproxy.linux.amd64 .")
                    }
                    else{
                     //   sh("gsutil cp gs://medipark-hospital-secrets/cloudsqlproxy.linux.amd64 .")
                    }
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
                            case "development":   
                                sh("sed -i.bak 's#service:#service: dev-${appName}#' app.yaml")    
							    // sh("gcloud app deploy --image-url ${imageTag} --version v${env.BUILD_NUMBER} --no-promote")
							   // sh("gcloud app services set-traffic dev-${appName} --splits v${env.BUILD_NUMBER}=.5, $previous_version=.5")
							   
				sh("bash appengine_versions_clean.sh dev-${appName} ${imageTag} v${env.BUILD_NUMBER} 3"); //script deploys, splits traffic and deletes old versions
                                break        
                            case "qa":
                                sh("sed -i.bak 's#service:#service: qa-${appName}#' app.yaml")
								//sh("gcloud app deploy --image-url ${imageTag} --version v${env.BUILD_NUMBER} --stop-previous-version")
				//sh("bash appengine_versions_clean.sh qa-${appName} 2");
				sh("bash appengine_versions_clean.sh qa-${appName} ${imageTag} v${env.BUILD_NUMBER} 3"); //script deploys, splits traffic and deletes old versions
                               
                                break
                            case "uat":   
                                sh("sed -i.bak 's#service:#service: uat-${appName}#' app.yaml")
							  //  sh("gcloud app deploy --image-url ${imageTag} --version v${env.BUILD_NUMBER} --stop-previous-version")
				//sh("bash appengine_versions_clean.sh uat-${appName} 2");
                                sh("bash appengine_versions_clean.sh uat-${appName} ${imageTag} v${env.BUILD_NUMBER} 3"); //script deploys, splits traffic and deletes old versions
                               
				break
                            case "prod":
                                sh("sed -i.bak 's#service:#service: ${appName}#' app.yaml")
							    //sh("gcloud app deploy --image-url ${imageTag} --version v${env.BUILD_NUMBER} --stop-previous-version")
				//sh("bash appengine_versions_clean.sh ${appName} 2");
                                sh("bash appengine_versions_clean.sh ${appName} ${imageTag} v${env.BUILD_NUMBER} 3"); //script deploys, splits traffic and deletes old versions
                               
				break   
                        }

                        configFileProvider(
                            [configFile(fileId: 'app_yaml', variable: 'DEPLOY')]){
                            sh("yes | cp -rf $DEPLOY ./app.yaml")
                        }
						
                    }                   
                       
            //END DEPLOY TO APPENGINE
      }   
  }
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
    slackSend (color: colorCode, message: summary)
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
