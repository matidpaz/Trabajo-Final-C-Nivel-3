<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoFormulario.aspx.cs" Inherits="WebApplication1.ProductoFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <form class="row">
            <div class="col-6">

                <div class="col-mb-3">
                    <%--campo ID --%>
                    <label for="txtId" class="form-label">Id del producto</label>
                    <asp:TextBox type="text" class="form-control" ID="txtId" oninput="validarCampo(this)" runat="server" />
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
                        Looks good!
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtCodigo" class="form-label">Codigo del producto</label>
                    <asp:TextBox type="text" ID="txtCodigo" CssClass="form-control" oninput="validarCampo(this)" ClientIDMode="Static" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="El campo 'Codigo' es oblogatorio" ControlToValidate="txtCodigo" runat="server" />
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtNombre" class="form-label">Nombre del producto</label>
                    <asp:TextBox type="text" ID="txtNombre" CssClass="form-control" oninput="validarCampo(this)" ClientIDMode="Static" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="El campo 'Nombre' es obligatorio" ControlToValidate="txtNombre" runat="server" />
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtDescripcion" class="form-label">Descripcion</label>
                    <asp:TextBox type="text" ID="txtDescripcion" CssClass="form-control" oninput="validarCampo(this)" ClientIDMode="Static" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="El campo 'Descripción' es obligatorio" ControlToValidate="txtDescripcion" runat="server" />
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>

                <div class="col-md-3">
                    <label for="ddlCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList CssClass="form-select is-invalid" ID="ddlCategoria" onchange="validarDdl(this)" ClientIDMode="Static" runat="server">
                    </asp:DropDownList>
                    <div id="verificacionDdlCategoria" class="invalid-feedback">
                        Please select a valid state.
                    </div>
                </div>

                <div class="col-md-3">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList CssClass="form-select is-invalid" ID="ddlMarca" onchange="validarDdl(this)" ClientIDMode="Static" runat="server">
                    </asp:DropDownList>
                    <div id="verificacionDdlMarca" class="invalid-feedback">
                        Please select a valid state.
                    </div>
                </div>



                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio del Artículo</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Ej: 1500.50" oninput="validarCampo(this)" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator ErrorMessage="El campo 'Precio' es obligatorio" ControlToValidate="txtPrecio" runat="server" />
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

                <div class="col-6">
                    <asp:Image ID="ImgUrl" CssClass="img-fluid" runat="server" onerror="this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg';" />
                </div>
                <%if (!(Request.QueryString["Id"] != null))
                    {%>
                <asp:Button ID="btnNuevo" CssClass="btn btn-success" runat="server" Text="Nuevo" ClientIDMode="Static" OnClientClick="return confirm('¿Estás seguro de que deseas crear un nuevo artículo?');" OnClick="btnNuevo_Click" />
                <%} %>

                <%else

                    {%>
               
                    <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="Modificar" ClientIDMode="Static" OnClientClick="return confirm('¿Estás seguro de que deseas modificar este artículo?');" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnBorrar" CssClass="btn btn-danger" runat="server" Text="Borrar" ClientIDMode="Static" OnClientClick="return confirm('¿Estás seguro de que deseas borrar este registro?');" OnClick="btnBorrar_Click" />
                
                <% } %>
                <div>
                </div>
                <div>
                </div>
            </div>
        </form>
    </div>
    <script>
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
        function activarBotones() {
            const codigo = document.getElementById("txtCodigo");
            const nombre = document.getElementById("txtNombre");
            const descripcion = document.getElementById("txtDescripcion");
            const categoria = document.getElementById("ddlCategoria");
            const marca = document.getElementById("ddlMarca");
            const precio = document.getElementById("txtPrecio");
            const botonGuardar = document.getElementById("btnNuevo");
            const botonModificar = document.getElementById("btnModificar");

            const codigoValido = codigo.value.trim().length > 0;
            const nombreValido = nombre.value.trim().length > 0;
            const descripcionValida = descripcion.value.trim().length > 0;
            const categoriaValida = categoria.value != "0";
            const marcaValida = marca.value != "0";
            const precioValido = /^\d+(?:[.,]\d{1,2})?$/.test(precio.value);

            if (codigoValido && nombreValido && descripcionValida && categoriaValida && marcaValida && precioValido) {
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
        window.activarBoton();
    </script>
</asp:Content>
