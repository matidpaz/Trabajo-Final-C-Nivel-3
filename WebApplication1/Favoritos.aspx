<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="WebApplication1.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Carrito de compras:</h2>
         <asp:UpdatePanel runat="server" ID="udpCardFavoritos">
             <ContentTemplate>

     <div class="row row-cols-1 row-cols-md-3 g-4">
            <%if (listaDeProductos != null && listaDeProductos.Count > 0)
                {
                    foreach (Dominio.Producto art in listaDeProductos)
                    {%>
                        <%--<div class="row row-cols-1 row-cols-md-3 g-4">--%>
                            <div class="col">
                               <%-- <div class="row">--%>

                                    <div class="card h-100 d-flex flex-column">
                                        <div style="height: 200px; overflow: hidden; display: flex; align-items: center; justify-content: center; background-color: #f8f9fa;">
                                            <img src="<%= art.ImagenArticulo %>" class="card-img-top" style="max-height: 100%; width: auto; object-fit: contain;" alt="..."
                                                onerror="this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg';">

                                        </div>

                                        <div class="card-body d-flex flex-column">
                                            <h5 class="card-title"><%= art.NombreArticulo %></h5>
                                            <p class="card-text text-secondary"><%= art.DescripcionArticulo %></p>

                                            <div class="mt-auto">
                                                <hr />
                                                <p class="fw-bold">Categoria: <%= art.CategoriaArticulo.Descripcion %></p>
                                                <p class="fw-bold">Marca: <%= art.MarcaArticulo.Descripcion %></p>
                                                <p class="fw-bold">$ <%= art.PrecioArticulo %></p>
                                                <a href="ProductoFormulario.aspx?Id=<%= art.Id %>&paginaAnterior = Default.aspx" class="btn btn-primary btn-md">Ver detalle</a>
                                                <%--< Debo usar un boton comun del tipo submit porque con foreach no tengo como mandar la info del boton especifico que clickeo, pero con submit si puedo capturar esa info escuchando manualmente>--%>
                                                <button id="btnElimiarFavorito" type="submit" name="idEliminarFavorito" value="<%=art.Id %>" class="btn btn-danger btn-md" onclick="">Eliminar de Favoritos</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                         <%--   </div> --%>
                        <%--</div>--%>
                    <% }
                        }
              else
                   {%>
                        <p>Tu carrito esta vacio. Ve y llenalo!</p>
                   <%}%>
     </div>
             </ContentTemplate>
         </asp:UpdatePanel>
         
                
</asp:Content>
