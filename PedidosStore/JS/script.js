//Functions navbar menu
let iconmenu = document.getElementById("iconmenu");
let btnmenu = document.getElementById("btn-menu");
let menu = document.getElementById("menu");
let activemenu = false;
btnmenu.addEventListener('click', () => {
    if (!activemenu) {
        iconmenu.classList.remove("fa-bars");
        iconmenu.classList.add("fa-times");
        menu.style.left = "0px";
        activemenu = true;
    } else {
        iconmenu.classList.add("fa-bars");
        iconmenu.classList.remove("fa-times");
        menu.style.left = "-320px";
        activemenu = false;
    }
})

//Function modals signup and login

let openmodal = document.getElementById("open-modal");
let closemodal = document.getElementById("close-modal");
let modal = document.getElementById("modal");
let formsignup = document.getElementById("form-signup");

openmodal.addEventListener('click', () => {
    modal.style.opacity = "10";
    modal.style.zIndex = "10";
    modal.style.background = "rgb(46, 46, 46, 0.50)";
    formsignup.style.transform = "scale(100%)";
})

closemodal.addEventListener('click', () => {
    modal.style.opacity = "0";
    modal.style.zIndex = "-10";
    modal.style.background = "none";
    formsignup.style.transform = "scale(0%)";
})


//Formulario pago functios

let btnpago = document.getElementById("btnpedido");
btnpago.addEventListener('click', (e) => {
    e.preventDefault;
})