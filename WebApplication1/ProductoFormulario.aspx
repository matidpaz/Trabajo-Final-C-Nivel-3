<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoFormulario.aspx.cs" Inherits="WebApplication1.ProductoFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .oculto {
            display: none
        }
    </style>
    <div class="container">
        <form class="row">
            <div class="col-6">

                <div class="col-mb-3">
                    <%--campo ID --%>
                    <label for="txtId" class="form-label oculto">Id del producto</label>
                    <asp:TextBox type="text" class="form-control oculto" ID="txtId" oninput="validarCampo(this)" runat="server" />
                    <asp:RequiredFieldValidator
                        runat="server"
                        Display="Dynamic"
                        ErrorMessage="Debe ingresar un Id"
                        ControlToValidate="txtId"
                        ForeColor="Red"
                        CssClass="valid-feedback">
                        <span class="icon-error"></span>
                    </asp:RequiredFieldValidator>
                    <div class="valid-feedback">
                        Correcto!
                    </div>
                </div>
                <%--campo Codigo/validacion --%>
                <div class="col-md-4">
                    <label for="txtCodigo" class="form-label">Codigo del producto</label>
                    <asp:TextBox type="text" ID="txtCodigo" CssClass="form-control" oninput="validarCampo(this)" ClientIDMode="Static" runat="server" />
                    <asp:RequiredFieldValidator
                        runat="server"
                        Display="Dynamic"
                        ErrorMessage="El campo 'Codigo' es oblogatorio"
                        ControlToValidate="txtCodigo"
                        SetFocusOnError="true"
                        ForeColor="Red"
                        CssClass="valid-feedback">
                        <span class="icon-error"></span>
                    </asp:RequiredFieldValidator>
                    <div class="valid-feedback">
                        Correcto!
                    </div>
                </div>
                <%--campo Nombre/validacion --%>
                <div class="col-md-4">
                    <label for="txtNombre" class="form-label">Nombre del producto</label>
                    <asp:TextBox type="text" ID="txtNombre" CssClass="form-control" oninput="validarCampo(this)" ClientIDMode="Static" runat="server" />
                    <asp:RequiredFieldValidator
                        runat="server"
                        Display="Dynamic"
                        ErrorMessage="El campo 'Nombre' es obligatorio"
                        ControlToValidate="txtNombre"
                        SetFocusOnError="true"
                        ForeColor="Red"
                        CssClass="valid-feedback">
                        <span class="icon-error"></span>
                    </asp:RequiredFieldValidator>
                    <div class="valid-feedback">
                        Correcto!
                    </div>
                </div>
                <%--campo Descripcion/validacion --%>
                <div class="col-md-4">
                    <label for="txtDescripcion" class="form-label">Descripcion</label>
                    <asp:TextBox type="text" ID="txtDescripcion" CssClass="form-control" oninput="validarCampo(this)" ClientIDMode="Static" runat="server" />
                    <asp:RequiredFieldValidator
                        runat="server"
                        Display="Dynamic"
                        ErrorMessage="El campo 'Descripción' es obligatorio"
                        ControlToValidate="txtDescripcion"
                        SetFocusOnError="true"
                        ForeColor="Red"
                        CssClass="valid-feedback">
                        <span class="icon-error"></span>
                    </asp:RequiredFieldValidator>
                    <div class="valid-feedback">
                        Correcto!
                    </div>
                </div>
                <%--campo Categoria/validacion --%>
                <div class="col-md-3">
                    <label for="ddlCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList
                        runat="server"
                        ID="ddlCategoria"
                        CssClass="form-select is-invalid"
                        onchange="validarDdl(this)"
                        ClientIDMode="Static">
                    </asp:DropDownList>
                    <div id="verificacionDdlCategoria"
                        class="valid-feedback">
                        Correcto!
                    </div>
                </div>
                <%--campo Marca/validacion --%>
                <div class="col-md-3">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList
                        runat="server"
                        ID="ddlMarca"
                        CssClass="form-select is-invalid"
                        onchange="validarDdl(this)"
                        ClientIDMode="Static">
                    </asp:DropDownList>
                    <div id="verificacionDdlMarca" class="valid-feedback">
                        Correcto!
                    </div>
                </div>
                <%--campo Imagen/validacion --%>
                <div class="mb-3">
                    <label for="txtImagen" class="form-label">Imagen de Articulo</label>
                    <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" placeholder="Ej: 1500.50" oninput="validarCampo(this)" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator
                        runat="server"
                        Display="Dynamic"
                        ErrorMessage="El campo 'Precio' es obligatorio"
                        ControlToValidate="txtImagen"
                        SetFocusOnError="true"
                        ForeColor="Red"
                        CssClass="valid-feedback">
                        <span class="icon-error"></span>
                    </asp:RequiredFieldValidator>
                </div>
                <%--campo Precio/Doble validacion (por campo vacio y por expresion regular) --%>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio del Artículo</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Ej: 1500.50" oninput="validarCampo(this)" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator
                        runat="server"
                        Display="Dynamic"
                        ErrorMessage="El campo 'Precio' es obligatorio"
                        ControlToValidate="txtPrecio"
                        ForeColor="Red"
                        CssClass="valid-feedback">
                        <span class="icon-error"></span>
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        ID="revPrecio"
                        runat="server"
                        ControlToValidate="txtPrecio"
                        ValidationExpression="^\d+(?:[.,]\d{1,2})?$"
                        Display="Dynamic"
                        ForeColor="Red"
                        CssClass="validador-estado"
                        ErrorMessage="Formato de precio inválido (use punto o coma para decimales)" />
                </div>
                <%--campo Imagen por defecto --%>
                <div class="col-6">
                    <asp:Image ID="ImgUrl" CssClass="img-fluid" runat="server" onerror="this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg';" />
                </div>
                <%--Muestra botones. Dependiendo si la redireccion ocurre con un parametro Id distinto de nulo, es porque voy a crear un nuevo artculo, sino es porque voy a modificar o eliminar --%>
                <%if (user != null)
                  {
                        if (user.PerfilAdmin == true)
                        {
                            if (!(Request.QueryString["Id"] != null))
                            {%>
                                <asp:Button ID="btnNuevo" CssClass="btn btn-success" runat="server" Text="Nuevo" ClientIDMode="Static" OnClientClick="return confirm('¿Estás seguro de que deseas crear un nuevo artículo?');" OnClick="btnNuevo_Click" />
                             <%}
                        else
                        {%>
                                <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="Modificar" ClientIDMode="Static" OnClientClick="return confirm('¿Estás seguro de que deseas modificar este artículo?');" OnClick="btnModificar_Click" />
                                <asp:Button ID="btnBorrar" CssClass="btn btn-danger" runat="server" Text="Borrar" ClientIDMode="Static" OnClientClick="return confirm('¿Estás seguro de que deseas borrar este registro?');" OnClick="btnBorrar_Click" />
                         <%}
                        }%>
                        <asp:Button ID="btnAgregarAFavoritos" Text="Agregar a favoritos" runat="server" CssClass ="btn btn-primary btn-md" OnClick="btnAgregarAFavoritos_Click" />
                <%} %>
                <div>
                </div>
                <div>
                </div>
            </div>
        </form>
    </div>
    <script>
        <%--Valida que los campos no esten vacios o completos con espacios, y hace visible el error --%>
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
        <%--Al crear un articulo los campos categoria y marca se inicializan con una leyenda que se corresponde con el valor cero, validando que se seleecione una opcion si o si --%>
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
        <%--Valida que los campos posean valor correcto para darle funcionalidad al boton que llama al evento en el servidor (validacion visual - acompañada de validacion en el servidor) --%>
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
        <%--Llamada a funcion que verifica los campos para hacer funcional a los botones que llaman a los eventos (para que no deba modificarse nada en los campos si estos ya vienen cargados correctamente) --%>
        window.activarBoton();
    </script>
</asp:Content>
