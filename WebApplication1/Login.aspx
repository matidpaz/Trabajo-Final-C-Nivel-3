<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .sin-borde {
            outline: none;
            border: 0;
        }
        .oculto {
            display: none;
        }
    </style>
    <main aria-labelledby="title">
        <h2 id="title">Ingresar</h2>
        <form>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox type="email" class="form-control" ID="txtEmail" aria-describedby="emailHelp" ClientIDMode="Static" runat="server" />
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox type="password" class="form-control" ID="txtPass" ClientIDMode="Static" runat="server" />
            </div>
            <asp:UpdatePanel ID="updLbl" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblMailOPassIncorecto" CssClass="oculto" ForeColor="Red" runat="server" ClientIDMode="Static">Mail o Pass incorrecto</asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3">
                <asp:CheckBox type="checkbox" CssClass="form-check-input sin-borde" ID="cbxRecordarme" runat="server" />
                <label class="form-check-label" for="cbxRecordarme">Recordarme</label>
            </div>
            <asp:Button ID="btnIngresar" type="submit" class="btn btn-primary" OnClick="btnIngresar_Click" Text="Ingresar" runat="server"></asp:Button>
            <asp:Button ID="btnRegistrarse" type="submit" class="btn btn-success" OnClick="btnRegistrarse_Click" Text="Registrarme" runat="server"></asp:Button>
        </form>
    </main>
</asp:Content>
