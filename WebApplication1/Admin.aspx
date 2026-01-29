<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Administracion de productos</h1>
            <p class="lead">Mi aplicacion de practica para mostrar productos en el sector de administracion.</p>
            <p><a href="/" class="btn btn-primary btn-md">Modo Público &raquo;</a></p>
        </section>

        <div>
            <asp:GridView Id="dgvProductos" AutoGenerateColumns="false" class="table table-dark table-striped" DataKeyNames="Id" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Codigo Articulo" DataField="CodigoArticulo"/>
                    <asp:BoundField HeaderText="Nombre Articulo" DataField="NombreArticulo"/>
                    <asp:BoundField HeaderText="Descripcion" DataField="DescripcionArticulo"/>
                    <asp:BoundField HeaderText="Categoria" DataField="CategoriaArticulo.Descripcion"/>
                    <asp:BoundField HeaderText="Marca" DataField="MarcaArticulo.Descripcion"/>
                    <asp:BoundField HeaderText="Precio" DataField="PrecioArticulo"/>
                    <asp:ButtonField  />
                    
                </Columns>
            </asp:GridView>
        </div>
        <div>
        </div>
    </main>
</asp:Content>
