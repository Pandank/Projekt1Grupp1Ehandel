using EhandelGrupp1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EhandelGrupp1.services
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["email"]) && !string.IsNullOrEmpty(Request["password"]))
            {
                var user = DataManagement.ValidateLogin(Request["email"], Request["password"]);
                LiteralLogin.Text = user;
            }
        }
    }
}