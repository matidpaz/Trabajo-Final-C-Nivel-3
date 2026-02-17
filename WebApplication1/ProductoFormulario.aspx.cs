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
        public User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuarioLogueado"] != null)
                {
                    user = (User)Session["usuarioLogueado"];
                }

                NegocioFunciones negocio = new NegocioFunciones();

                if (!IsPostBack)
                {
                    ddlCategoria.DataSource = negocio.listarCategorias();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoria", "0"));

                    ddlMarca.DataSource = negocio.listarMarcas();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                    ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", "0"));

                    if (Request.QueryString["Id"] != null)
                    {
                        List<Producto> listaDeProductos = (List<Producto>)Session["listaDeProductos"];
                        int Id = int.Parse(Request.QueryString["Id"]);
                        Producto productoSeleccionado = negocio.buscarPorId(Id);

                        txtId.Text = productoSeleccionado.Id.ToString();
                        txtId.ReadOnly = true;
                        txtCodigo.Text = productoSeleccionado.CodigoArticulo.ToString();
                        txtCodigo.CssClass += " is-valid";
                        txtNombre.Text = productoSeleccionado.NombreArticulo.ToString();
                        txtNombre.CssClass += " is-valid";
                        txtDescripcion.Text = productoSeleccionado.DescripcionArticulo.ToString();
                        txtDescripcion.CssClass += " is-valid";
                        txtImagen.Text = string.IsNullOrEmpty(productoSeleccionado.ImagenArticulo) ? "https://www.site.com/imagen-por-defecto.png" : productoSeleccionado.ImagenArticulo;
                        txtImagen.CssClass += " is-valid";
                        ddlCategoria.SelectedValue = productoSeleccionado.CategoriaArticulo.Id.ToString();
                        ddlCategoria.CssClass = ddlCategoria.CssClass.Replace("is-invalid", "is-valid");
                        ddlMarca.SelectedValue = productoSeleccionado.MarcaArticulo.Id.ToString();
                        ddlMarca.CssClass = ddlMarca.CssClass.Replace("is-invalid", "is-valid");
                        txtPrecio.Text = productoSeleccionado.PrecioArticulo.ToString("F2");
                        txtPrecio.CssClass += " is-valid";
                    }
                }      
            }
            catch (Exception ex)
            {
                Session.Add("explicacion", "Fallo en Page_Load - ProductoFormulario");
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid)
                {
                    return;
                }
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                int categoria = int.Parse(ddlCategoria.SelectedValue);
                int marca = int.Parse(ddlMarca.SelectedValue);
                string imagen = txtImagen.ToString();
                decimal precio = decimal.Parse(txtPrecio.Text);

                NegocioFunciones negocio = new NegocioFunciones();
                int idNuevo = negocio.crearArticulo(codigo, nombre, descripcion, categoria, marca, imagen, precio);

                if (Request.QueryString["paginaAnterior"] != null)
                {
                    string paginaAnterior = Request.QueryString["paginaAnterior"];
                    Response.Redirect(paginaAnterior + "?Id= " + idNuevo);
                }
            }
            catch (Exception ex)
            {
                Session.Add("explicacion", "Fallo en btnNuevo_Click - ProductoFormulario");
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid)
                {
                    return;
                }
                //Agregar validacion de campo modificado, para que no pueda mandar la modificacion a la base de datos sin haber modificado ningun atributo - Tambien en JavaScript
                NegocioFunciones negocio = new NegocioFunciones();
                int IdTomado = int.Parse(txtId.Text);
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                int categoria = int.Parse(ddlCategoria.SelectedValue);
                int marca = int.Parse(ddlMarca.SelectedValue);
                string imagen = ImgUrl.ToString();
                decimal precio = decimal.Parse(txtPrecio.Text);
                negocio.modificarArticulo(IdTomado,codigo,nombre,descripcion,categoria,marca,imagen,precio);

                Session.Add("listaDeProductos", negocio.listarProductos());
                Response.Redirect(Request.QueryString["paginaAnterior"], false);
            }
            catch (Exception ex)
            {
                Session.Add("explicacion", "Fallo en btnModificar_Click - ProductoFormulario");
                Session.Add("error", ex.ToString());
                Session.Add("error", ex.ToString());
                 
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioFunciones negocio = new NegocioFunciones();
                int IdTomado = int.Parse(txtId.Text);
                negocio.eliminarArticulo(IdTomado);
                Session.Add("listaDeProductos", negocio.listarProductos());
                //Response.Redirect(Request.QueryString["paginaAnterior"], false);
            }
            catch (Exception ex)
            {
                Session.Add("explicacion", "Fallo en btnBorrar_Click - ProductoFormulario");
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregarAFavoritos_Click(object sender, EventArgs e)
        {
            NegocioFunciones negocio = new NegocioFunciones();
            User user = (User)Session["usuarioLogueado"];
            try
            {
                Button btn = (Button)sender;
                int idFavorito = int.Parse(btn.CommandArgument);
                if (user != null)
                {
                    user.Favoritos.Add(negocio.buscarPorId(idFavorito));
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?error= " + ex.Message, false);
            }
        }
    }
}