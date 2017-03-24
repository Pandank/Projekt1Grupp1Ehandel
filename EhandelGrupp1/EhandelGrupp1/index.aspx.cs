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
            int userID = DataManagement.CreateCustomer("hakan@kvarnskogen.st", "Håkan", "Johansson", "0", "Kalle");
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

        //returns the json of PRODUCT with ID
        private static string GetProductById(int id)
        {
            using (var db = new EHandel())
            {
                var query = from p in db.Product
                            where p.productId == id
                            select new
                            {
                                p.productId,
                                p.name,
                                p.description,
                                p.price,
                                p.stock,
                                p.date
                            };

                return ObjTooJson.ObjToJson(query);
            }
        }

        //returns ALL products ( json )
        private static string GetAllProducts()
        {
            using (var db = new EHandel())
            {
                var query = from p in db.Product
                            select new
                            {
                                p.productId,
                                p.name,
                                p.description,
                                p.price,
                                p.stock,
                                p.date
                            };

                return ObjTooJson.ObjToJson(query);
            }
        }

        //returns ALL catagory names as json
        private static string GetAllCategoryNames()
        {
            using (var db = new EHandel())
            {
                var query = from b in db.Category
                            select b.name;

                return ObjTooJson.ObjToJson(query);
            }
        }



    }
}