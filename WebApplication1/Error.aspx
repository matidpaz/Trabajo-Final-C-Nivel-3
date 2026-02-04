<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebApplication1.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>HAS SIDO REDIRIGIDO A LA PAGINA DE ERROR</h1>
        <h2>Error: <%=MensajeDeError %></h2>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <p>Explicacion: <%=Explicacion%></p>
        <asp:Label ID="lblExplicacion" runat="server"></asp:Label>
    </div>
</asp:Content>
