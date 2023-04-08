function errorpedido() {
    Swal.fire({
        icon: 'error',
        title: 'Su carrito de compras esta vacio.',
    })
}

function errorproducto() {
    Swal.fire({
        icon: 'error',
        title: 'Llene todo los campos por favor.',
    })
}

function errorSignup() {
    Swal.fire({
        icon: 'error',
        title: 'Registrese correctamente por favor.',
    })
}

function errorSignupData() {
    Swal.fire({
        icon: 'error',
        title: 'Usuario, correo o teléfono ya son usados por otro usuario.',
    })
}

function succesSignUp(businessName) {
    swal.fire(
        'En hora buena!',
        'Su información se registro exitosamente, bienvenido a ' + businessName + '.',
        'success'
    )
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
        parent.location.href = "/"
    });
}