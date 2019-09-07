function Slide() {
    $('#shipping-inner').slideUp(400);
    $('#payment-inner').slideDown(400);
    PaymentSelect();    
}   

function PaymentSelect() {
    var cash = document.getElementById('cash-img');
    var credit = document.getElementById('credit-img');
    var payment_cash = document.getElementById('payment-cash');
    var payment_credit = document.getElementById('payment-credit');
    var visa = document.getElementById('visa-img');
    var mastercard = document.getElementById('mastercard-img');
    var payment_fields = document.getElementById('payment-fields');
    
    cash.addEventListener('click', () => {
        payment_cash.classList.remove('hide');
        payment_credit.classList.add('hide'); 
    });
    credit.addEventListener('click', () => {
        payment_cash.classList.add('hide');
        payment_credit.classList.remove('hide');
    });
    visa.addEventListener('click', () => {
        payment_fields.classList.remove('hide');
    });
    mastercard.addEventListener('click', () => {
        payment_fields.classList.remove('hide');
    });
}
