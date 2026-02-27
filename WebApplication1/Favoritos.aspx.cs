using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebApplication1
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Producto> listaDeProductos;
        public User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuarioLogueado"] != null)
                {
                    user = (User)Session["usuarioLogueado"];
                    listaDeProductos = user.Favoritos;
                }
                else
                {
                    var ex = "No tienes acceso a esta seccion. Primero debes registrarte como Usuario";
                    Response.Redirect("Error.aspx?ex= " + ex, false); //Error para el usuario. Manejado. No necesito reporte de esto.
                }

                if (IsPostBack)
                {
                    if (user != null)
                    {
                        string eliminarDeFavorito = Request.Form["idEliminarFavorito"];
                        if (!string.IsNullOrEmpty(eliminarDeFavorito))
                        {
                            int idEliminarFavorito = int.Parse(eliminarDeFavorito);
                            user.Favoritos = user.Favoritos.FindAll(x => x.Id != idEliminarFavorito);
                            
                            Response.Redirect("Favoritos.aspx", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string descripcion = "Page_Load - Carrito.aspx";
                Response.Redirect("Error.aspx?ex= " + ex.Message + "&&explicacion= " + descripcion, false); //Para error tecnico - Averiguar si puedo hacer que me llegue un reporte al mail con este error
            }
        }

        
    }
}