$(document).ready(function () {
    $("#html").addClass("scroll-none");
    $(".footer-container").addClass("hide");
    $(window).on("load",function(){
        $(".spinner-3").fadeOut("slow");
        $("#html").removeClass("scroll-none");
        if ($(".main-cart").length) {
            $("#html").addClass("scroll-none");
        }
        else {
            $("#html").removeClass("scroll-none");
        }
        $(".footer-container").removeClass("hide");
    });
})

$(document).ready(function () {
    $('.icon').click(function () {
        $('.icon').toggleClass('active');
        $('#categories-container').toggleClass('slide');
    });
})


