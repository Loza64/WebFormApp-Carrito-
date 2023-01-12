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

//Sweet alert`s functions
function errorpedido() {
    Swal.fire({
        icon: 'error',
        title: 'Su carrito de compras esta vacio, escoja almenos un producto',
    })
}

function errorproducto() {
    Swal.fire({
        icon: 'error',
        title: 'Llene todo los campos por favor',
    })
}

function load() {
    let timerInterval
    Swal.fire({
        title: 'Realizando pedido, por favor espere!',
        html: 'Por favor espere <b></b>.',
        timer: 2000,
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading()
            timerInterval = setInterval(() => {
                const content = Swal.getHtmlContainer()
                if (content) {
                    const b = content.querySelector('b')
                    if (b) {
                        b.textContent = Swal.getTimerLeft()
                    }
                }
            }, 100)
        },
        willClose: () => {
            clearInterval(timerInterval)
        }
    }).then((result) => {
        /* Read more about handling dismissals below */
        if (result.dismiss === Swal.DismissReason.timer) {
            alertme();
        }
    })
}

function alertme() {
    swal.fire(
        "En hora buena!",
        "Su pedido se realizo de manera exitosa, te hemos enviado un email con tu numero de pedido junto con los productos que solicitates, si no lo recives realiza tu pedido nuevamente.",
        "success"
    ).then(function () {
        parent.location.href = "Principal.aspx"
    });
}