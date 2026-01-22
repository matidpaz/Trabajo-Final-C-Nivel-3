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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["error"] != null)
            {
                MensajeDeError = Request.QueryString["error"];
            }
        }
    }
}