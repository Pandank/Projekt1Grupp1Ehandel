using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EhandelGrupp1
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildSidebarCategorys();
        }

        private void BuildSidebarCategorys()
        {
            string categorys = null;
            var catNames = DataManagement.GetAllCategoryNamesO();
            foreach (var catName in catNames)
            {
                var catID = DataManagement.GetCategoryIdFromNameO(catName);
                var path = @"index.aspx?category=" + catID;
                categorys += @"<li class='category'><a href='" + path + "'>" + catName + "</a></li>";
            }
            LiteralCategorys.Text = categorys;
        }
    }
}