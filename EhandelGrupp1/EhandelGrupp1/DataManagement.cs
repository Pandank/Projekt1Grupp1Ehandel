using EhandelGrupp1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EhandelGrupp1
{
    public class DataManagement
    {

        /// <summary>
        /// Returns ALL products as JSON
        /// </summary>
        /// <returns></returns>
        public static string GetAllProducts()
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




        /// <summary>
        /// Returns the product in Json Format with specific Name
        /// </summary>
        /// <param name="productName">Name of the product</param>
        /// <returns></returns>
        public static string GetProductByName(string productName)
        {
            using (var db = new EHandel())
            {
                var query = from p in db.Product
                            where p.name == productName
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
        /// <summary>
        /// Returns specific product in Json Format with specific ID
        /// </summary>
        /// <param name="productID">Name of the product</param>
        /// <returns></returns>
        public static string GetProductByID(int productID)
        {
            using (var db = new EHandel())
            {
                var query = from p in db.Product
                            where p.productId == productID
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


        /// <summary>
        /// Returns ALL Catagory NAMES
        /// </summary>
        /// <returns></returns>
        public static string GetAllCategoryNames()
        {
            using (var db = new EHandel())
            {
                var query = from b in db.Category
                            select b.name;

                return ObjTooJson.ObjToJson(query);
            }
        }






        /// <summary>
        /// Creates a new customer returns the user ID
        /// </summary>
        /// <param name="email">Email Of Customer</param>
        /// <param name="firstname">Firstname Of Customer</param>
        /// <param name="lastname">Lastname Of Customer</param>
        /// <param name="isAdmin">if the user is admin 0 or 1 as a char</param>
        /// <param name="password">Password of Customer</param>
        /// <returns></returns>
        public static int CreateCustomer(string email, string firstname, string lastname, string isAdmin, string password)
        {

            Customer c = new Customer
            {
                email = email,
                firstname = firstname,
                lastname = lastname,
                isAdmin = isAdmin,
                password = password
            };


            using (var db = new EHandel())
            {
                db.Customer.Add(c);
                db.SaveChanges();
            }

            return c.userId;
        }

        /// <summary>
        /// Updates an existing Customer
        /// </summary>
        /// <param name="userID">userID of customer</param>
        /// <param name="email">Email Of Customer</param>
        /// <param name="firstname">Firstname Of Customer</param>
        /// <param name="lastname">Lastname Of Customer</param>
        /// <param name="isAdmin">if the user is admin 0 or 1 as a char</param>
        /// <param name="password">Password of Customer</param>
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