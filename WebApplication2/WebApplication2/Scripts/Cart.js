var html = document.getElementById('html');
var page_wrap = document.getElementById('page-wrap');
var page_click_event = document.getElementById('page-click-event');
// Cart var
var cart = document.getElementById('cart');
var cart_added = document.getElementById('cart-added');
var cart_popup = document.getElementById('cart-popup');
var main_cart = document.getElementById('main-cart');
var btn_continue = document.getElementById('btn-cnt');
var btn_check = document.getElementById('btn-check');
var cart_close = document.getElementById('cart-close');
var remove_items = document.getElementById('remove-cart-items');
var li_last = document.getElementById('li-last');
var amount_incart = document.getElementById('amount-items-incart');

function updateCartWidget(data) {
    $('#cart-popup-inner').replaceWith('<div class="cart-popup-inner-wrapper" id="cart-popup-inner">' + data + '</div>');
}
function reloadCounter(data) {
    $('#counter').replaceWith('<p id="counter">' + data + '</div>');
}
//Cart functions
function mouseOver() {
    cart_popup.classList.remove('hide');
}

function mouseOut() {
    cart_popup.classList.add('hide');
}

function updateCartCounter() {
    $.post(
        "/Cart/CartCounter",
        reloadCounter
    );
}

function added(e) {
    updateCartCounter();
    cart_added.classList.remove('hide');
    setTimeout(() => {
        cart_added.classList.add('hide');
    }, 2000);
}

$("body").on('DOMSubtreeModified', "#main-cart-inner", function () {
    updateCartCounter();
    mainCartCheck();
});

function mainCartOpen() {
    main_cart.classList.remove('main-cart-popout');
    html.classList.add('scroll-none');
    page_wrap.classList.add('darken');
    main_cart.classList.remove('hide');
    page_click_event.classList.add('page-click-event-off');
    page_wrap.addEventListener('click', checkCart);
}

function mainCartCheck() {
    if ($("#empty-cart").length) {
        $("#btn-check").attr("disabled", true);
        remove_items.classList.add('hidden');
    }
    else {
        $("#btn-check").attr("disabled", false);
        remove_items.classList.remove('hidden');
    }
}

function mainCartClose() {
    updateCartCounter();
    main_cart.classList.add('main-cart-popout');
    page_wrap.classList.remove('darken');
    page_click_event.classList.remove('page-click-event-off');
    setTimeout(() => {
        html.classList.remove('scroll-none');
        main_cart.classList.add('hide');
    }, 300);
    $.post(
        "/Cart/CartWidget",
        updateCartWidget
    );
}

function cartAmountCircle () {
    amount_incart.classList.remove('hidden');
}

function checkCart () {
if (page_wrap.classList.contains('darken')) {
    mainCartClose();
}
}

//Event listeners
cart.addEventListener('mouseover', mouseOver);
cart.addEventListener('mouseout', mouseOut);

cart_popup.addEventListener('mouseover', mouseOver);
cart_popup.addEventListener('mouseout', mouseOut);

btn_continue.addEventListener('click', mainCartClose);
cart_close.addEventListener('click', mainCartClose);

$(document).ready(function(){
    li_last.addEventListener("animationend", cartAmountCircle);
})