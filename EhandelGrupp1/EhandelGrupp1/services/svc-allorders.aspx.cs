using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EhandelGrupp1;

namespace EhandelGrupp1.services
{
    public partial class svc_allorders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var allOrders = DataManagement.GetAllOrders();
            LiteralAllOrders.Text = allOrders;
        }
    }
}