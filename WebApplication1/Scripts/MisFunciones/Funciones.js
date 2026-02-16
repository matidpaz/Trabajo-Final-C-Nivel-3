/*Valida que los campos no esten vacios o completos con espacios, y hace visible el error*/
function validarCampo(campo) {
    if (campo.value.trim() != "") {
        campo.classList.remove("is-invalid");
        campo.classList.add("is-valid");

    }
    else {
        campo.classList.remove("is-valid");
        campo.classList.add("is-invalid");

    }
    activarBoton();
}
/*Al crear un articulo los campos categoria y marca se inicializan con una leyenda que se corresponde con el 
    valor cero, validando que se seleecione una opcion si o si*/
function validarDdl(campo) {
    if (campo.value != 0) {
        campo.classList.remove("is-invalid");
        campo.classList.add("is-valid");
    }
    else {
        campo.classList.remove("is-valid");
        campo.classList.add("is-invalid");
    }
    activarBoton();
}
/*Valida que los campos posean valor correcto para darle funcionalidad al boton que llama al evento en el 
    servidor(validacion visual - acompañada de validacion en el servidor)*/
function activarBotones() {
    const codigo = document.getElementById("txtCodigo");
    const nombre = document.getElementById("txtNombre");
    const descripcion = document.getElementById("txtDescripcion");
    const categoria = document.getElementById("ddlCategoria");
    const marca = document.getElementById("ddlMarca");
    const imagen = document.getElementById("txtImagen");
    const precio = document.getElementById("txtPrecio");
    const botonGuardar = document.getElementById("btnNuevo");
    const botonModificar = document.getElementById("btnModificar");

    const codigoValido = codigo.value.trim().length > 0;
    const nombreValido = nombre.value.trim().length > 0;
    const descripcionValida = descripcion.value.trim().length > 0;
    const categoriaValida = categoria.value != "0";
    const marcaValida = marca.value != "0";
    const imagenValida = imagen.value.trim().length > 0;
    const precioValido = /^\d+(?:[.,]\d{1,2})?$/.test(precio.value);

    if (codigoValido && nombreValido && descripcionValida && categoriaValida && marcaValida && imagenValida && precioValido) {
        botonGuardar.disabled = false;
        botonGuardar.classList.remove("btn-secondary");
        botonGuardar.classList.add("btn-primary");

        botonModificar.disabled = false;
        botonModificar.classList.remove("btn-secondary");
        botonModificar.classList.add("btn-primary");

    }
    else {
        botonGuardar.disabled = true;
        botonGuardar.classList.remove("btn-primary");
        botonGuardar.classList.add("btn-secondary");

        botonModificar.disabled = true;
        botonModificar.classList.remove("btn-primary");
        botonModificar.classList.add("btn-secondary");

    }
}
/*Funcion para activar/desactivar boton "Modificar"" si este no no sufre modificaciones en sus campos*/
function capturarEstadosViejos()
{
    const emailViejo = document.getElementById("txtEmail").value.trim();
    const passViejo = document.getElementById("txtPass").value.trim();
    const nombreViejo = document.getElementById("txtNombre").value.trim();
    const apellidoViejo = document.getElementById("txtApellido").value.trim();
    const imagenVieja = document.getElementById("txtImagenUsuario").value.trim();
    const listaVieja = [emailViejo, passViejo, nombreViejo, apellidoViejo, imagenVieja];
    return listaVieja;
}

function capturarEstadosNuevos()
{
    const emailNuevo = document.getElementById("txtEmail").value.trim();
    const passNueva = document.getElementById("txtPass").value.trim();
    const nombreNuevo = document.getElementById("txtNombre").value.trim();
    const apellidoNuevo = document.getElementById("txtApellido").value.trim();
    const imagenNueva = document.getElementById("txtImagenUsuario").value.trim();
    var listaNueva = [emailNuevo, passNueva, nombreNuevo, apellidoNuevo, imagenNueva]
    return listaNueva;
}

function ActivarBoton()
{
    var listaNueva = capturarEstadosNuevos();

    const boton = document.getElementById("btnModificar")
    var cambioEmail = listaVieja[0] == listaNueva[0] ? true : false;
    var cambioPass = listaVieja[1] == listaNueva[1] ? true : false;
    var cambioNombre = listaVieja[2] == listaNueva[2] ? true : false;
    var cambioApellido = listaVieja[3] == listaNueva[3] ? true : false;
    var cambioImagen = listaVieja[4] == listaNueva[4] ? true : false;

    if (cambioEmail==true && cambioPass==true && cambioNombre==true && cambioApellido==true && cambioImagen==true)
    {
        boton.disabled = true;
        boton.classList.replace("btn-primary", "btn-secondary");
    }
    else
    {
        boton.disabled = false;
        boton.classList.replace("btn-secondary", "btn-primary")
    }

    
}
