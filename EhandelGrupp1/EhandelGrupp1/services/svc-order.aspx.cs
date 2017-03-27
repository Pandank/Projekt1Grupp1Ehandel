using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EhandelGrupp1;

namespace EhandelGrupp1.services
{
    public partial class svc_order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["userId"]))
            {
                var order = DataManagement.GetAllOdersByCustomerID(int.Parse(Request["userId"]));
                LiteralOrder.Text = order;
            }

        }
    }
}