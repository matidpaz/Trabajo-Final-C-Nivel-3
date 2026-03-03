using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

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
                //string mensaje = Server.UrlEncode(ex.Message);
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

       
        //Si el campo de texto a buscar tiene contenido, guarda los valores de idCat e idMar en otras dos variables en sesion, las primeras las setea en "0" y ejecuta la funcion de busqueda
        //Luego si el campo de busqueda esta vacio, recupera los valores originales de idCat e idMar para que recuerde la seleccion anterior por marca y categoria
        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioFunciones negocio = new NegocioFunciones();
                List<Producto> listaDeProductos = negocio.listarProductos();
                string fragmento = txtbuscar.Text;
                if (!string.IsNullOrEmpty(fragmento))
                {
                    btnLimpiarFiltro.Visible = true;
                }
                
                Session.Add("idCategoriaARecordar", Session["idCat"]);
                Session.Add("idMarcaARecordar", Session["idMar"]);
                Session["idCat"] = 0;
                Session["idMar"] = 0;
                listaDeProductos = negocio.busquedaAvanzada(listaDeProductos, fragmento);
                Session["listaDeProductos"] = listaDeProductos;
                
            }
            catch (Exception ex)
            {
                string descripcion = "btnBuscar_Click - Site.Master.cs";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idCategoriaARecordar"] != null && Session["idMarcaARecordar"] != null)
                {
                    Session["idCat"] = Session["idCategoriaARecordar"];
                    Session["idMar"] = Session["idMarcaARecordar"];
                }
                txtbuscar.Text = string.Empty;
                btnLimpiarFiltro.Visible = false;
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                string descripcion = "btnLimpiarFiltro_Click - Site.Master.cs";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }
    }
}