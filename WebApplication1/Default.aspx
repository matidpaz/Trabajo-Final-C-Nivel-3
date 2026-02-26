<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <style>
            .oculto {
                display: none;
            }

            .card-img-top {
                width: 100%;
                height: 250px; /* Define una altura fija para todas las tarjetas*/
                object-fit: contain; /* Ajusta la imagen sin recortarla */
                background-color: #f8f9fa; /* Fondo gris claro para rellenar espacios vacíos */
            }

            .estilo {
                background: linear-gradient(to right, #eef2f3, #8e9eab);
            }

            .card:hover {
                transform: scale(1.02);
                transition: all 0.3s ease;
                box-shadow: 0 10px 20px rgba(0,0,0,0.1) !important;
            }

            
        </style>

        <section class="row" aria-labelledby="aspnetTitle">
            <%if (TipoUser == "1")
                {%>
            <h1 id="aspnetTitle">Home/Admin</h1>
            <%}
                else
                {%>
            <h1 id="aspnetTitle">Home</h1>
            <%} %>
            <p class="lead">Mi aplicacion de practica para mostrar productos.</p>
            <%if (TipoUser == "1")
                {%>
            <p><a href="Admin.aspx" class="btn btn-primary btn-md">Modo Admin &raquo;</a></p>
            <%} %>
            <br />
            <%if (TipoUser == "1")
                {%>
            <p><a href="ProductoFormulario.aspx" class="btn btn-primary btn-md">Registrar nuevo Articulo</a></p>
            <%} %>
        </section>

        <div class="row row-cols-1 row-cols-md-3 g-4">
            <%if (true)
                {

                } %>
            <%List<Dominio.Producto> lista = (List<Dominio.Producto>)Session["listaDeProductos"]; %>
            <% foreach (Dominio.Producto art in lista)
                { %>
            <div class="col">
                <div class="card h-100 d-flex flex-column shadow-sm card:hover">
                    <img src="<%= art.ImagenArticulo %>" class="card-img-top" alt="..."
                        onerror="this.src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg';">

                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title"><%= art.NombreArticulo %></h5>
                        <p class="card-text text-secondary"><%= art.DescripcionArticulo %></p>

                        <%-- El margen superior automático (mt-auto) empuja el botón hacia abajo --%>
                        <div class="mt-auto">
                            <hr />


                            <p class="fw-bold">Categoria: <%= art.CategoriaArticulo.Descripcion %></p>
                            <p class="fw-bold">Marca: <%= art.MarcaArticulo.Descripcion %></p>
                            <p class="fw-bold">$ <%= art.PrecioArticulo %></p>
                            <a href="ProductoFormulario.aspx?Id=<%= art.Id %>&paginaAnterior = Default.aspx" class="btn btn-primary btn-md">Ver detalle</a>
                            <%if (TipoUser == "1" || TipoUser == "0")
                                {%>
                            <button id="selectFavorito" type="submit" name="idFavorito" value="<%=art.Id %>" class="btn btn-primary" onclick="">Agregar a favoritos</button>

                            <%} %>

                            <%--agregar una validacion que cuando el usuario sea admin vaya a default pero que diga "HOME / ADMIN" y un boton que permita ver
   los productos en modo admin, y modo usuario con un boton en la tarjeta del producto para mofificar a este.--%>
                        </div>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </main>

</asp:Content>



