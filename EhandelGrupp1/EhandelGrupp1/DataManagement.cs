using EhandelGrupp1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EhandelGrupp1
{
    public class DataManagement
    {
        public static string GetProductByName(string name)
        {
            using (var db = new EHandel())
            {
                var query = from p in db.Product
                            where p.name == name
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

        public static int CreateCustomer(string email, string firstname, string lastname, string isAdmin, string password)
        {

            Customer c = new Customer();

            c.email = email;
            c.firstname = firstname;
            c.lastname = lastname;
            c.isAdmin = isAdmin;
            c.password = password;

            using (var db = new EHandel())
            {
                db.Customer.Add(c);
                db.SaveChanges();
            }

            return c.userId;
        }
        public static void UpdateCustomer(int userID, string email, string firstname, string lastname, string isAdmin, string password)
        {
            using (var db = new EHandel()) //använda databasen
            {
                Customer cust = db.Customer.FirstOrDefault(c => c.userId == userID); //Hitta första som matchar userID

                if(cust != null)
                {
                    cust.email = email;
                    cust.firstname = firstname;
                    cust.lastname = lastname;
                    cust.isAdmin = isAdmin;
                    cust.password = password;
                }
                db.SaveChanges();
            }
        }

    }

}