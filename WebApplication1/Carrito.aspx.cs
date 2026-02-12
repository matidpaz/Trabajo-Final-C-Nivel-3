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
            listaDeProductos = new List<Producto>();
            if (Session["usuarioLogueado"] != null)
			{
				User user = new User();
				listaDeProductos = user.Favoritos;
			}
			else
			{
				
            }
		}
	}
}