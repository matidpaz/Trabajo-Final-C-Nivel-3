using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Error : System.Web.UI.Page
    {
        public string MensajeDeError { get; set; }
        public string Explicacion { get; set; }
        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblError.Text = Session["error"].ToString();
                lblError.Text = Session["explicacion"].ToString();
                MensajeDeError = Session["error"].ToString();
                Explicacion = Session["explicacion"].ToString();
            }
        }
    }
}