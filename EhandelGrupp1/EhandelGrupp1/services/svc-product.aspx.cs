using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EhandelGrupp1.services
{
    public partial class svc_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                var product = DataManagement.GetProductByID(int.Parse(Request["id"].ToString()));
                LiteralProduct.Text = product;
            }
        }
    }
}