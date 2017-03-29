using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EhandelGrupp1.services
{
    public partial class svc_order_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["orderId"]))
            {
                var order = DataManagement.GetOrderByID(int.Parse(Request["orderId"]));
                LiteralOrderDetails.Text = order;
            }
        }
    }
}