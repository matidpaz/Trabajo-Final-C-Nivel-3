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
        public List<Producto> listaDeProductos = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuarioLogueado"] != null)
                {
                    User user = (User)Session["usuarioLogueado"];
                    listaDeProductos = user.Favoritos;
                }
                else
                {
                    var ex = "No tienes acceso a esta seccion. Primero debes registrarte como Usuario";
                    Response.Redirect("Error.aspx?ex= " + ex, false); //Error para el usuario. Manejado. No necesito reporte de esto.
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?ex= " + ex, false); //Para error tecnico - Averiguar si puedo hacer que me llegue un reporte al mail con este error
            }
        }
    }
}