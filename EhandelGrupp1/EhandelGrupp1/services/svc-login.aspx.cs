using EhandelGrupp1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EhandelGrupp1.services
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["email"]) && !string.IsNullOrEmpty(Request["password"]))
            {
                var user = ValidateLogin(Request["email"], Request["password"]);
                LiteralLogin.Text = user;
            }
        }

        /// <summary>
        /// Returns the USER if login is correct (email/password)
        /// </summary>
        /// <param name="email">Email of customer</param>
        /// <param name="password">Password of customer</param>
        /// <returns></returns>
        private string ValidateLogin(string email, string password)
        {
            using (var db = new EHandel())
            {
                var query = from u in db.Customer
                            where u.email == email &&
                                  u.password == password
                            select new
                            {
                                u.isAdmin,
                                u.userId,
                                u.email,
                                u.firstname,
                                u.lastname,
                                u.Address,
                            };

                return ObjTooJson.ObjToJson(query);
            }
        }
    }
}