using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.AspNet.FriendlyUrls;
using Negocio;
using ConexionDB;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        public string TipoUser { get; set; }
		public User user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try 
	        {
				if (Session["usuarioLogueado"] != null)
				{
					TipoUser = ((Dominio.User)Session["usuarioLogueado"]).PerfilAdmin == true ? "1" : "0";
					user = (Dominio.User)Session["usuarioLogueado"];
                }
				

				List<Producto> listaDeProductos = new List<Producto>();
				NegocioFunciones negocio = new NegocioFunciones();

				listaDeProductos = negocio.listarProductos();

				if (listaDeProductos != null)
				{
					Session.Add("listaDeProductos",listaDeProductos);
				}
				if (IsPostBack)
				{
					string capturarId = Request.Form["idFavorito"];
					if (!string.IsNullOrEmpty(capturarId))
					{
						int id = int.Parse(capturarId);
						Producto prod = negocio.buscarPorId(id);

                        user.Favoritos.Add(prod);
					}
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