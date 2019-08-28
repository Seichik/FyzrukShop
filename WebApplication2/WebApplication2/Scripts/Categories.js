var list = document.getElementById('list');
var categories = document.getElementById('categories-container');
var close = document.getElementById('close');

//Categories open
function opening() {
    categories.classList.remove('hide');
    list.classList.add('hide');
}

//Categories close
function closing() {
    categories.classList.add('slideout');
    setTimeout(() => {
        categories.classList.add('hide');
        list.classList.remove('hide');
        categories.classList.remove('slideout');
    }, 200)
}

//Event listeners
list.addEventListener('click', opening);

close.addEventListener('click', closing);
