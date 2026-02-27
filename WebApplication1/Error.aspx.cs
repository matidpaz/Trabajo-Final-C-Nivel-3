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
     
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["error"] != null)
                {
                    lblError.Text = Request.QueryString["error"].ToString();
                    lblExplicacion.Text = Request.QueryString["explicacion"].ToString();                
                }
            }
            catch (Exception ex)
            {
                string descripcion = "Page_Load - Error";
                Response.Redirect("Error.aspx?error= " + ex.Message + " &&explicacion= " + descripcion, false);
            }
        }
    }
}