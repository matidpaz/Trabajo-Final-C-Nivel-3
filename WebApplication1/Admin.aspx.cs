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
                try
                {
                    //lista = (List<Producto>)Session["listaDeProductos"];
                    dgvProductos.DataSource = (List<Producto>)Session["listaDeProductos"];
                    dgvProductos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("explicacion", "Fallo en Page_Load - Admin");
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx",false);
                }
            }
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvProductos.SelectedDataKey.Value.ToString());
                Response.Redirect("ProductoFormulario?Id= " + id + "&paginaAnterior=Admin.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("explicacion", "Fallo en dgvProductos_SelectedIndexChanged - Admin");
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}