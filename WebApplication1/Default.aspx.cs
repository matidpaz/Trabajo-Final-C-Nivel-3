using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.AspNet.FriendlyUrls;
using Negocio;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        public bool EsAdmin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try 
	        {
				if (Session["usuarioLogueado"] != null)
				{
					EsAdmin = ((Dominio.User)Session["usuarioLogueado"]).PerfilAdmin;
				}
				else
				{
					EsAdmin = false;
				}
				List<Producto> listaDeProductos = new List<Producto>();
				NegocioFunciones negocio = new NegocioFunciones();

				listaDeProductos = negocio.listarProductos();

				if (listaDeProductos != null)
				{
					Session.Add("listaDeProductos",listaDeProductos);
				}

	        }
	        catch (Exception ex)
	        {
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
	        }

}
    }
}