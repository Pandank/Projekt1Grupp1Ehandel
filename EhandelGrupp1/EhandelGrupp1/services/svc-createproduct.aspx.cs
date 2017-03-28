using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EhandelGrupp1;
using Newtonsoft.Json;

namespace EhandelGrupp1.services
{
    public partial class svc_createproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["addProduct"]))
            {
                // Kolla så all data finns
                string name = !string.IsNullOrEmpty(Request["name"]) ? Request["name"].Trim() : "";
                string description = !string.IsNullOrEmpty(Request["description"]) ? Request["description"].Trim() : "";
                string stringprice = !string.IsNullOrEmpty(Request["price"]) ? Request["price"].Trim() : ""; //decimal
                string stringstock = !string.IsNullOrEmpty(Request["stock"]) ? Request["stock"].Trim() : ""; //int
                string stringdate = !string.IsNullOrEmpty(Request["date"]) ? Request["date"].Trim() : "";
                string stringisHidden = !string.IsNullOrEmpty(Request["isHidden"]) ? Request["isHidden"].Trim() : ""; //Byte

                if (name.Length > 0 && description.Length > 0 && stringprice.Length > 0 && stringstock.Length > 0 && stringdate.Length > 0 && stringisHidden.Length > 0)
                {
                    decimal price = Convert.ToDecimal(stringprice);
                    int stock = Convert.ToInt32(stringstock);
                    DateTime date = Convert.ToDateTime(stringdate);
                    byte isHidden = Convert.ToByte(stringisHidden);

                    int productId = DataManagement.CreateProduct(name, description, price, stock, date, isHidden);

                    LiteralCreateProduct.Text = JsonConvert.SerializeObject(productId);

                }
            }
        }
    }
}