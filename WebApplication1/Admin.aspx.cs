using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {
        //List<Producto> lista = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((List<Producto>)Session["listaDeProductos"] != null)
            {
                //lista = (List<Producto>)Session["listaDeProductos"];
                dgvProductos.DataSource = (List<Producto>)Session["listaDeProductos"];
                dgvProductos.DataBind();
            }
        }
    }
}