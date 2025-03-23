using System.Web.UI.WebControls;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
namespace proje3
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.Url.ToString().ToLower().IndexOf("default.aspx") > -1) || (Request.Url.ToString().ToLower().IndexOf(".aspx") == -1))
            {
                pnMenu.Visible = false;
            }
            else
            {
                pnMenu.Visible = true;
            }
        }
    }
}