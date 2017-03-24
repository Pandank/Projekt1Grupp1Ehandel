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
            string email = "admin";
            string password = "admin";

            var test = ValidateLogin(email,password);
        }




        //takes user input as param returns user as json if email and password is correct if not returns "empty" json
        private  string ValidateLogin(string email, string password)
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