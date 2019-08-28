
function Slide() {
    $('#shipping-inner').slideUp(400);
    $('#payment-inner').slideDown(400);
}

$(document).ready(function(){
    $("#cash-img").click(function(){
        $("#payment-cash").removeClass("hide");
        $("#payment-credit").addClass("hide");
    });
    $("#credit-img").click(function(){
        $("#payment-cash").addClass("hide");
        $("#payment-credit").removeClass("hide");
    });
});