using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioFunciones negocio = new NegocioFunciones();
            try
            {
                if (!IsPostBack)
                {
                    repCategorias.DataSource = negocio.listarCategorias();
                    repCategorias.DataBind();
                    repMarcas.DataSource = negocio.listarMarcas();
                    repMarcas.DataBind();
                    
                }
            }
            catch (Exception ex)
            {
                string descripcion = "Page_Load - Site.Master.cs";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
            
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuarioLogueado"] != null)
                {
                    Session.Remove("usuarioLogueado");
                    Session.Abandon();
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                string descripcion = "btnCerrarSesion_Click - Site.Master.cs";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }

        protected void btnCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string id = btn.CommandArgument;
                Session["idCat"] = id;
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                string descripcion = "btnCategoria_Click - Site.Master.cs";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }

        protected void btnMarca_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string id = btn.CommandArgument;
                Session["idMar"] = id;
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                string descripcion = "btnMarca_Click - Site.Master.cs";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }
    }
}