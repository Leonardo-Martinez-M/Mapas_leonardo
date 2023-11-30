//Genera un número aleatorio entre el 0 y el 9
var numeroAleatorio = Math.floor(Math.random() * 9);


//Creamos un arreglo de strings con los ID's de los videos
let VideoId = ["0rzAluuejUw", "Rw-_NOsDkW8", "WUkR1uh1hXE", "Y3V76QUVcm8", "Nu6nhz0Qo40", "CcFRpc1hfSI", "2zHpbpjUUY4", "jTGbfYCsopI", "BkH5sMX6whk",
    "0lXQpj9ewoc"];

//Éste código carga el IFrame Player API Code de manera Asícrona

//Creamos un elemento "Script"
var tag = document.createElement('script');

tag.src = "https://www.youtube.com/iframe_api";

var primerScriptTag = document.getElementsByTagName('script')[0];
primerScriptTag.parentNode.insertBefore(tag, primerScriptTag);


//Ésta función crea un <IFrame> (Youtube Player) y después el API CODE

var player;
function onYoutubeFrameApiReady() {
    player = new YT.Player('player', {
        height: '360',
        width: '640',
        videoId: VideoId[numeroAleatorio],
        events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });
}

//La API llamará a estas función cuando el video esté listo
function onPlayerReady() {
    event.target.playVideo();

}



//
var done = false;

function onPlayerStateChange(event) {
    if (event.data == YT.PlayerState.PLAYING && !done) {
        setTimeout(stopVideo, 6000);
        done = true;
    }
}

function stopVideo() {
    player.stopVideo();
}