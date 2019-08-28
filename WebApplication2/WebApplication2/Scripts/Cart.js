var body = document.getElementById('body');
var page_wrap = document.getElementById('page-wrap');
var page_click_event = document.getElementById('page-click-event');
// Cart var
var cart = document.getElementById('cart');
var cart_popup = document.getElementById('cart-popup');
var cart_added = document.getElementById('cart-added');
var main_cart = document.getElementById('main-cart');
var btn_continue = document.getElementById('btn-cnt');
var cart_close = document.getElementById('cart-close');

function updateCartWidget(data) {
    $('#cart-popup-inner').replaceWith('<div class="cart-popup-inner-wrapper" id="cart-popup-inner">' + data + '</div>');
}
//Cart functions
function mouseOver() {
    cart_popup.classList.remove('hide');
}

function mouseOut() {
    cart_popup.classList.add('hide');
}

function added(e) {
    cart_added.classList.remove('hide');
    setTimeout(() => {
        cart_added.classList.add('hide');
    }, 2000);
}


function mainCartOpen() {
    main_cart.classList.remove('main-cart-popout');
    body.classList.add('scroll-none');
    page_wrap.classList.add('darken');
    main_cart.classList.remove('hide');
    page_click_event.classList.add('page-click-event-off');
    page_wrap.addEventListener('click', checkCart);
}

function mainCartCheck() {
    if ($("#empty-cart:visible")) {
        $("#btn-check").attr("disabled", true);
    }
    else {
        $("#btn-check").attr("disabled", false);
    }
}

function mainCartClose() {
    main_cart.classList.add('main-cart-popout');
    page_wrap.classList.remove('darken');
    page_click_event.classList.remove('page-click-event-off');
    setTimeout(() => {
        body.classList.remove('scroll-none');
        main_cart.classList.add('hide');
    }, 300);
    $.post(
        "/Cart/CartWidget",
        updateCartWidget
    );
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