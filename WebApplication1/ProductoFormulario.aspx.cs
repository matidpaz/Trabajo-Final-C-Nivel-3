using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace WebApplication1
{
    public partial class ProductoFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    NegocioFunciones negocio = new NegocioFunciones();

                    ddlMarca.DataSource = negocio.listarMarcas();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                    ddlMarca.Items.Insert(0, new ListItem("Seleccione una categoria", "0"));

                    ddlCategoria.DataSource = negocio.listarCategorias();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoria", "0"));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}