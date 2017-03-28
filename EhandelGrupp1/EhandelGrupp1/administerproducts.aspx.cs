using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EhandelGrupp1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //BuildProductCategoryList();
            RefreshDropDown();

            //var test = DataManagement.GetCategoryIdFromNameO()
        }

        private void RefreshDropDown()
        {
            categoryList.Items.Clear();

            var catNames = DataManagement.GetAllCategoryNamesO();
            foreach (var catName in catNames)
            {
                int catID = DataManagement.GetCategoryIdFromNameO(catName);
                ListItem item = new ListItem(catName, catID.ToString());
                categoryList.Items.Add(item);
            }            
        }

        //private void BuildProductCategoryList()
        //{
        //    string productCategorys = null;
        //    var catNames = DataManagement.GetAllCategoryNamesO();
        //    foreach (var catName in catNames)
        //    {
        //        var catID = DataManagement.GetCategoryIdFromNameO(catName);
        //        productCategorys += @"<option value='" + catID + "'>" + catName + "</option>";
        //        //var path = @"index.aspx?category=" + catID;
        //        //productCategorys += @"<li><a href='" + path + "'>" + catName + "</a></li>";
        //    }
        //    LiteralProductCategorys.Text = productCategorys;

        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{




        //}
    }
}