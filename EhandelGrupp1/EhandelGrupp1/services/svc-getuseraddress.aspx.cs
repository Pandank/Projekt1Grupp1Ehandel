using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EhandelGrupp1.services
{
    public partial class svc_getuseraddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["userId"]))
            {
                var address = DataManagement.GetAdressByUserId(int.Parse(Request["userId"]));
                LiteralGetUserAddress.Text = address;
            }

        }
    }
}