using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EhandelGrupp1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildCategoryMenu();
        }




        private void BuildCategoryMenu()
        {
            string categorys = null;
            var catNames = DataManagement.GetAllCategoryNamesO();
            foreach (var catName in catNames)
            {
                var catID = DataManagement.GetCategoryIdFromNameO(catName);
                var path = @"index.aspx?category=" + catID;
                categorys += @"<li class='"+"categoryMobileMenu"+"'><a href='" + path + "'>" + catName + "</a></li>";
            }
            LiteralMobileCategoryList.Text = categorys;
        }

    }
}