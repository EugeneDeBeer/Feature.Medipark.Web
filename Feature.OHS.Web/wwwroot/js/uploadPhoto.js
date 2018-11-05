function hideSnap(){
var x = document.getElementById("snapCanvas").style.display="block";
var y = document.getElementById("takePhoto").style.display="block";
var z = document.getElementById("uploadPhoto");
if(x.display ==="block")
  {
    z.style.display = "none";
  }
    console.log("snap is removed");
}

function showSnap(){
  var x = document.getElementById("snapCanvas").style.display = "none";
  var y = document.getElementById("takePhoto").style.display = "none";
  var z= document.getElementById("uploadPhoto");
     if(z.style.display==="block")
     {
      x.style.display = "none";
     y.style.display = "none";
     }
      console.log("snap is shown");
}
/*function displayPicture(){
var x = document.getElementById("takePhoto");
if(x.style.display ==="none"){
     x.style.display = "block";
    } else {
        x.style.display ="none";
    }
    
   x.style.display="none";
}*/

var video = document.querySelector("#videoElement");
 
if (navigator.mediaDevices.getUserMedia) {       
    navigator.mediaDevices.getUserMedia({video: true})
  .then(function(stream) {
    video.srcObject = stream;
  })
  .catch(function(err0r) {
    console.log("Something went wrong!");
  });
}
 
var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d');

document.getElementById('snap').addEventListener('click',function(){
context.drawImage(video,0,0,255,255)
});