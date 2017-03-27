using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EhandelGrupp1.EF;

namespace EhandelGrupp1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                // visa produkt
                var product = DataManagement.GetProductByID(int.Parse(Request["id"].ToString()));
                LiteralProduct.Text = product;
            }
            else if (!string.IsNullOrEmpty(Request["category"]))
            {
                // visa alla produkter i given kategori
                var products = DataManagement.GetAllProductsFromCategory(int.Parse(Request["category"].ToString()));
                LiteralCategory.Text = products;
            }
            else
            {
                // visa startsidan
                var products = DataManagement.GetAllProducts();                
                LiteralStart.Text = products;
            }
        }
    }
}