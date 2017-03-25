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
            //int userID = DataManagement.CreateCustomer("hakan@kvarnskogen.st", "Håkan", "Johansson", "0", "Kalle");

            //Gets all products from specific category
            //var tests = DataManagement.GetAllProductsFromCategory("Övrigt");
        }




        /// <summary>
        /// Returns the USER if login is correct (email/password)
        /// </summary>
        /// <param name="email">Email of customer</param>
        /// <param name="password">Password of customer</param>
        /// <returns></returns>
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