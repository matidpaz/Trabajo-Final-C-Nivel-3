<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoFormulario.aspx.cs" Inherits="WebApplication1.ProductoFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validarCampo(campo) {
            if (campo.value != "")
            {
                campo.classList.remove("is-invalid");
                campo.classList.add("is-valid");
               
            }
            else
            {
                campo.classList.remove("is-valid");
                campo.classList.add("is-invalid");
                
            }
            activarBoton();
        }
        function validarDdl(campo) {
            if (campo.value != 0)
            {
                campo.classList.remove("is-invalid");
                campo.classList.add("is-valid");
            }
            else
            {
                campo.classList.remove("is-valid");
                campo.classList.add("is-invalid");
            }
            activarBoton();
        }
        function activarBoton() {
            const nombre = document.getElementById("txtNombre");
            const precio = document.getElementById("txtPrecio");
            const boton = document.getElementById("btnEnviar");
            console.log("Paso las primeras 3 constantes");
            const precioValido = /^\d+(?:[.,]\d{1,2})?$/.test(precio.value);
            const nombreValido = nombre.value.trim().length > 0;
            console.log("constantes con validaciones");
            if (precioValido && nombreValido)
            {   
                console.log("Entro al If");
                boton.disabled = false;
                console.log("boton.disabled");
                boton.classList.remove("btn-secondary");
                console.log("boton.classList.remove");
                boton.classList.add("btn-primary");
                console.log("boton.classList.add");
                
                
            }
            else
            {
                console.log("Entro al else");
                boton.disabled = true;
                console.log("boton.disabled");
                boton.classList.remove("btn-primary");
                console.log("boton.classList.remove");
                boton.classList.add("btn-secondary");
               
                
            }
        }
    </script>
    <form class="row g-3">
        <div class="col-md-4">
            <%--campo ID --%>
            <label for="txtId" class="form-label">Id del producto</label>
            <asp:TextBox type="text" class="form-control" ID="txtId" onblur="validarCampo(this)" runat="server" />
            <asp:RequiredFieldValidator 
                runat="server" 
                Display ="Dynamic" 
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
            <asp:TextBox type="text" ID="txtCodigo" CssClass="form-control" onblur="validarCampo(this)" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="El campo 'Codigo' es oblogatorio" ControlToValidate="txtCodigo" runat="server" />
            <div class="valid-feedback">
                Looks good!
            </div>
        </div>
        <div class="col-md-4">
            <label for="txtNombre" class="form-label">Nombre del producto</label>
            <asp:TextBox type="text"  ID="txtNombre" CssClass="form-control" onblur="validarCampo(this)" ClientIDMode="Static" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="El campo 'Nombre' es obligatorio" ControlToValidate="txtNombre" runat="server" />
            <div class="valid-feedback">
                Looks good!
            </div>
        </div>
        <div class="col-md-4">
            <label for="txtDescripcion" class="form-label">Descripcion</label>
            <asp:TextBox type="text"  ID="txtDescripcion" CssClass="form-control" onblur="validarCampo(this)" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="El campo 'Descripción' es obligatorio" ControlToValidate="txtDescripcion" runat="server" />
            <div class="valid-feedback">
                Looks good!
            </div>
        </div>

        <div class="col-md-3">
            <label for="ddlCategoria" class="form-label">Categoria</label>
            <asp:dropdownlist class="form-select is-invalid" id="ddlCategoria" onchange="validarDdl(this)" runat="server">
            </asp:dropdownlist>
            <div id="verificacionDdlCategoria" class="invalid-feedback">
                Please select a valid state.
            </div>
        </div>

        <div class="col-md-3">
            <label for="ddlMarca" class="form-label">State</label>
            <asp:dropdownlist class="form-select is-invalid" id="ddlMarca" onchange="validarDdl(this)" runat="server">
                
            </asp:dropdownlist>
            <div id="verificacionDdlMarca" class="invalid-feedback" >
                Please select a valid state.
            </div>
        </div>

        <div class="mb-3">
            <label for="validationTextarea" class="form-label">Textarea</label>
            <asp:TextBox class="form-control" ID="validationTextarea" placeholder="Required example textarea" required="true" runat="server" />
            <div class="invalid-feedback">
                Please enter a message in the textarea.
            </div>
        </div>

        <div class="mb-3">
            <label for="txtPrecio" class="form-label">Precio del Artículo</label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Ej: 1500.50" onblur="validarCampo(this)" ClientIDMode="Static"/>
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
        <div>
            <asp:Button Id="btnEnviar" CssClass="btn btn-secondary" runat="server" Text="Enviar" ClientIDMode="Static"/>
        </div>
    </form>
</asp:Content>
