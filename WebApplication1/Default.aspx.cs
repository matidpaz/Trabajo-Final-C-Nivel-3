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

		public int idCat { get; set; } = 0;

		public int idMar { get; set; } = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
			List<Producto> listaDeProductos;
			NegocioFunciones negocio = new NegocioFunciones();
         
            try 
	        {
				idCat = Session["idCat"] != null ? int.Parse(Session["idCat"].ToString()) : 0;
				idMar = Session["idMar"] != null ? int.Parse(Session["idMar"].ToString()) : 0;
				listaDeProductos = negocio.listarProductos();
				
				
				if (Session["usuarioLogueado"] != null)
				{
					TipoUser = ((Dominio.User)Session["usuarioLogueado"]).PerfilAdmin == true ? "1" : "0"; // talvez una modificacion aqui..
					user = (Dominio.User)Session["usuarioLogueado"];
				}
		
				if (listaDeProductos != null)
				{
					if (idCat != 0)
					{
						listaDeProductos = negocio.filtrarPorCategoria(listaDeProductos, idCat);
						
					}
					if(idMar != 0)
					{
						listaDeProductos = negocio.filtrarPorMarca(listaDeProductos, idMar);
                    }
                    Session.Add("listaDeProductos", listaDeProductos);
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
                string descripcion = "Fallo en Page_Load - Default";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }

}

        
    }
}