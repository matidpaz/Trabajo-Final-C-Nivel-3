using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using ServicioEmail;


namespace WebApplication1
{
    public partial class FormularioUser : System.Web.UI.Page
    {
        public bool Registrado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {   
            try
            {
                Registrado = Session["usuarioLogueado"] != null ? true : false;
                if (!IsPostBack)
                {             
                    if (Registrado)
                    {
                        User user = (User)Session["usuarioLogueado"];
                        txtEmail.Text = user.EmailUsuario.ToString();
                        txtPass.Text = user.PassUsuario.ToString();
                        txtNombre.Text = user.NombreUsuario == null ? "" : user.NombreUsuario.ToString();
                        txtApellido.Text = user.ApellidoUsuario == null ? "" : user.ApellidoUsuario.ToString();
                        txtImagenUsuario.Text = user.ImagenPerfil == null ? "" : user.ImagenPerfil.ToString();
                        imgPerfil.Src = user.ImagenPerfil == null ? "" : user.ImagenPerfil.ToString();
                        configuracionDeControles();
                    }
                    else
                    {
                        //var ex = "Para ingresar primero debes registrarte como Usuario";
                        //Response.Redirect("Error.aspx?ex= " + ex, false);
                    }
                }
                configuracionDeControles();
            }
            catch (Exception ex)
            {
                string descripcion = "Fallo en Page_Load - FormularioUser";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }
        //recordar revisar para hashear las contraseñas que se guardan en la base de datos
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioFunciones negocio = new NegocioFunciones();
                User user = new User();
                
                if (negocio.verificarEmail(txtEmail.Text.Trim()))
                {
                    lblMailIncorecto.CssClass += " oculto";

                    EmailService emailService = new EmailService();
                    user.EmailUsuario = txtEmail.Text.Trim();
                    user.PassUsuario = txtPass.Text.Trim();
                    user.NombreUsuario = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim().ToString();
                    user.ApellidoUsuario = string.IsNullOrEmpty(txtApellido.Text.Trim()) ? null : txtApellido.Text.Trim().ToString();
                    user.ImagenPerfil = string.IsNullOrEmpty(txtImagenUsuario.Text.Trim()) ? null : txtImagenUsuario.Text.Trim().ToString();
                    negocio.crearUser(user);
                    Session.Add("usuarioLogueado", user);
                    Registrado = Session["usuarioLogueado"] != null ? true : false;
                    configuracionDeControles();
                    emailService.armarCorreo(user.EmailUsuario, "Bienvenida usuario", "Este mail es solo para darte la bienvenida..");
                    emailService.enviarMail();
                }
                else
                {
                    lblMailIncorecto.CssClass = lblMailIncorecto.CssClass.Replace("oculto", "");
                }

            }
            catch (Exception ex)
            {
                string descripcion = "btnAceptar_Click - FormularioUser";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }     
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            NegocioFunciones negocio = new NegocioFunciones();
            User user = (User)Session["usuarioLogueado"];
            try
            {
                user.NombreUsuario = string.IsNullOrEmpty(txtNombre.Text) ? null : txtNombre.Text.Trim().ToString();
                user.ApellidoUsuario = string.IsNullOrEmpty(txtApellido.Text) ? null : txtApellido.Text.Trim().ToString();
                user.ImagenPerfil = string.IsNullOrEmpty(txtImagenUsuario.Text) ? null : txtImagenUsuario.Text.Trim().ToString();
                User userModificado = negocio.modificarUsuario(user);
                Session["usuarioLogueado"] = userModificado;
            }
            catch (Exception ex)
            {
                string descripcion = "btnModificar_Click - FormularioUser";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }
        private void configuracionDeControles() //Esta funcion es para ponerla en otro lado creo
        {
            try
            {
                if (Session["usuarioLogueado"] != null)
                {
                    btnModificar.Visible = true;
                    btnAceptar.Visible = false;
                }
                else
                {
                    btnAceptar.Visible = true;
                    btnModificar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string descripcion = "configuracionDeControles - FormularioUser";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }
    }
}