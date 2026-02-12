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
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioUser.aspx", false);
        }
    }
}