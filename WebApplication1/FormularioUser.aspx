<%@ Page Title="FormularioUser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioUser.aspx.cs" Inherits="WebApplication1.FormularioUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--tener en cuenta: si llego aca por precionar registrarme: todos los campos en blanco. sino, mail y contraseña (cifrada) cargados + atributos que ya tenga cargados el usuario--%>
    <%--Ver si puedo crear un Super usuario que sea el unico que puede convertir en administrador o no a cada usuario--%>

    <style>
        .oculto {
            display: none;
        }
    </style>
    <form>
        <h2>Para Registrarse complete los siguientes campos:</h2>
        <%--Campo id no visible--%>
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3 oculto">
                    <label for="idUser" class="form-label">Id</label>
                    <asp:TextBox type="Text" CssClass="form-control" ID="idUser" ClientIDMode="Static" runat="server" />
                    <div id="idHelp" class="form-text"></div>
                </div>
                <%--Campo mail - validar con JavaScript y servidor--%>
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email address</label>
                    <asp:TextBox type="email" class="form-control" ID="txtEmail" ClientIDMode="Static" runat="server" aria-describedby="emailHelp" oninput="ActivarBoton()" />
                    <asp:Label ID="lblMailIncorecto" CssClass="oculto" ForeColor="Red" runat="server">Debe seleccionar otro email</asp:Label>
                    <div id="emailHelp" class="form-text">Campo obligatorio</div>
                </div>
                <%--Campo pass - validar con JavaScript y servidor--%>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Password</label>
                    <asp:TextBox type="password" CssClass="form-control" ID="txtPass" ClientIDMode="Static" runat="server" oninput="ActivarBoton()" />
                    <div id="passHelp" class="form-text">Campo obligatorio</div>
                </div>
                <%--Campo Nombre - puede ser null--%>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox type="text" CssClass="form-control" ID="txtNombre" ClientIDMode="Static" runat="server" aria-describedby="emailHelp" oninput="ActivarBoton()" />
                    <div id="nombreHelp" class="form-text"></div>
                </div>
                <%--Campo Apellido - puede ser null--%>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox type="text" class="form-control" ID="txtApellido" ClientIDMode="Static" runat="server" aria-describedby="emailHelp" oninput="ActivarBoton()" />
                    <div id="apellidoHelp" class="form-text"></div>
                </div>
                <%--Campo Imagen de Usuario - puede ser null pero debe tener una por defecto para que no se rompa--%>
                <div class="mb-3">
                    <label for="txtImagenUsuario" class="form-label">Imageb</label>
                    <asp:TextBox type="text" class="form-control" ID="txtImagenUsuario" ClientIDMode="Static" runat="server" aria-describedby="emailHelp" oninput="ActivarBoton()" />
                    <div id="imagenHelp" class="form-text"></div>
                </div>
                <%--Campo Admin - No visible, se inicializa en null y se adminitra con super usuario--%>
                <div class="mb-3 oculto">
                    <label for="isAdmin" class="form-label">Perfil Administrador</label>
                    <div></div>
                    <asp:CheckBox type="checkbox" ID="isAdmin" ClientIDMode="Static" runat="server" aria-describedby="emailHelp" />
                    <div id="isAdminHelp" class="form-text"></div>
                </div>
            </div>
            <div class="col-md-6 d-flex flex-column align-items-center justify-content-center">
                <label class="form-label">Previsualización:</label>
                <img id="imgPerfil" runat="server" src="https://via.placeholder.com/250"
                    class="img-thumbnail" style="width: 250px; height: 250px; object-fit: cover;"
                    onerror="this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'"/>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <%if (Registrado)
                        {%>

                    <asp:Button ID="btnModificar" type="submit" Text="Modificar" class="btn btn-primary" OnClick="btnModificar_Click" runat="server" ClientIDMode="Static"></asp:Button>
                    <%}
                        else
                        { %>
                    <asp:Button ID="btnAceptar" type="submit" Text="Aceptar" class="btn btn-primary" OnClick="btnAceptar_Click" runat="server"></asp:Button>
                    <%}%>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
    <script>
        var listaVieja = capturarEstadosViejos();
        ActivarBoton();
    </script>

</asp:Content>
