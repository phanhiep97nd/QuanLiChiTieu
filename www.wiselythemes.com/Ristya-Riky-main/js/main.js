// window.addEventListener("load", function () {
//     const loader = document.querySelector(".cover");
//     loader.className += " hidden"; // class "loader hidden"
//     document.body.style.overflow = "hidden";
// });
function changeBackground(color) {
    document.body.style.background = color;
}

window.addEventListener("load", function() { changeBackground('white') });

$(document).ready(() => {
    getUrl();
});

function getUrl() {
    var url = window.location.href;
    var str = url.split('%');
    var name = str.pop();
    $('#name').html(name);

}
$(document).ready(function() {
    $(".preloader").fadeOut();
})

$(window).on('load', function() {


    // audio


    //scrollIt
    $.scrollIt({
        topOffset: 0
    });


})

$(window).scroll(function() {
    if ($(this).scrollTop() > 800) {
        $(".header").addClass("fixed");
        $(".fa-pause").addClass("fixed");
        $(".backtop").addClass("fixed")

    } else {
        $(".header").removeClass("fixed");
        $(".fa-pause").removeClass("fixed");
        $(".backtop").removeClass("fixed")
    }
})

// $(".cover .open").click(function(){
//     document.body.style.overflow = "visible";
// })



var swiper = new Swiper(".mySwiper", {
    loop: true,
    spaceBetween: 5,
    slidesPerView: 5,
    freeMode: true,
    watchSlidesProgress: true,
});
var swiper2 = new Swiper(".mySwiper2", {
    loop: true,
    spaceBetween: 5,
    focus: 'center',
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    thumbs: {
        swiper: swiper,
    },
});

$(window).on('load', function() {

    document.body.style.overflow = "visible";

    $("#myAudio")[0].play();
})

// audio

$(".fa-pause").click(function() {

    if ($(this).hasClass("pause")) {
        $("#myAudio")[0].play();
        console.log("play");
    } else {
        $("#myAudio")[0].pause();
        console.log("pause");
    }
    $(this).toggleClass("pause");
})
let btn = document.querySelector(".toogle");
let icon = btn.querySelector(".fa-pause");

btn.onclick = function() {
    if (icon.classList.contains("fa-pause")) {
        icon.classList.replace("fa-pause", "fa-play");
    } else {
        icon.classList.replace("fa-play", "fa-pause");
    }
}