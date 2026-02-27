using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApplication1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            NegocioFunciones negocio = new NegocioFunciones();
            User user = new User(); 
            try
            {
                var email = txtEmail.Text;
                var algo = txtPass.Text;
                user.EmailUsuario = txtEmail.Text;
                user.PassUsuario = txtPass.Text;
                User userExistente = negocio.verificarUser(user);
                if (userExistente != null)
                {
                    Session.Add("usuarioLogueado", userExistente);
                    Response.Redirect("FormularioUser.aspx", false);
                }
                else
                {
                    lblMailOPassIncorecto.CssClass = lblMailOPassIncorecto.CssClass.Replace("oculto", "");
                }
            }
            catch (Exception ex)
            {
                string descripcion = "btnIngresar_Click - Login";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FormularioUser.aspx", false);
            }
            catch (Exception ex)
            {
                string descripcion = "btnRegistrarse_Click - Login";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }
    }
}