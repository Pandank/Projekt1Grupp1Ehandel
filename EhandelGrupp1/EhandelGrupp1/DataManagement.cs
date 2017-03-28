using EhandelGrupp1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace EhandelGrupp1
{
    public static class DataManagement
    {

        /// <summary>
        /// Returns order by order id
        /// </summary>
        /// <param name="orderID">ID of the order</param>
        /// <returns></returns>
        public static string GetOrderByID(int orderID)
        {
            using (var db = new EHandel())
            {

                var query = from p in db.Product
                            join obp in db.OrdersByProduct on p.productId equals obp.productId
                            where obp.orderId == orderID
                            select new
                            {
                                p.productId,
                                p.name,
                                obp.count,
                                obp.price,

                            };
                return ObjTooJson.ObjToJson(query.ToList());
            }
        }

        /// <summary>
        /// returns all order by CUSTOMER ID
        /// </summary>
        /// <param name="userID">ID of CUSTOMER to get orders</param>
        /// <returns></returns>
        public static string GetAllOdersByCustomerID(int userID)
        {
            using (var db = new EHandel())
            {
                var query = from o in db.Orders
                            where o.userId == userID
                            select new
                            {
                                o.orderId,
                                o.date,
                                o.status
                            };
                return ObjTooJson.ObjToJson(query.ToList());
            }
        }

        /// <summary>
        /// Returns the USER if login is correct (email/password)
        /// </summary>
        /// <param name="email">Email of customer</param>
        /// <param name="password">Password of customer</param>
        /// <returns></returns>
        public static string ValidateLogin(string email, string password)
        {
            using (var db = new EHandel())
            {
                var query = db.Customer
                    .FirstOrDefault(c => c.email == email && c.password == password);

                //var query = from u in db.Customer
                //            where u.email == email &&
                //                  u.password == password
                //            select new
                //            {
                //                u.isAdmin,
                //                u.userId,
                //                u.email,
                //                u.firstname,
                //                u.lastname,
                //                u.Address
                //            };

                return ObjTooJson.ObjToJson(new List<Customer> { query });
            }
        }

    //Creates a new Product, returns Product ID //CS
    /// <summary>
    /// Creates a new PRODUCT returns product ID
    /// </summary>
    /// <param name="name">Name of product</param>
    /// <param name="description">Product description</param>
    /// <param name="price">price of product</param>
    /// <param name="stock">Stock</param>
    /// <param name="date">datetime of time when product was added</param>
    /// <param name="isHidden"> null or 0 for not hidden set to 1 to hide product</param>
    /// <returns>Returns the product ID</returns>
    public static int CreateProduct(string name, string description, decimal price, int stock, DateTime date, byte isHidden)
    {
        Product p = new Product
        {
            name = name,
            description = description,
            price = price,
            stock = stock,
            date = date,
            isHidden = isHidden

        };
        using (var db = new EHandel())
        {
            db.Product.Add(p);
            db.SaveChanges();
        }

        return p.productId;
    }

    //Create a new Category, returns Category ID //CS
    public static int CreateCategory(string name)
    {
        Category c = new Category
        {
            name = name,
        };

        using (var db = new EHandel())
        {
            db.Category.Add(c);
            db.SaveChanges();
        }
        return c.categoryId;
    }

    /// <summary>
    /// Returns ALL products from specific CATEGORY
    /// </summary>
    /// <param name="categoryID">CategoryID to get products from</param>
    /// <returns></returns>
    public static string GetAllProductsFromCategory(int categoryID)
    {
        using (var db = new EHandel())
        {
            var query = from p in db.Product
                        join ctp in db.CategoryToProduct on p.productId equals ctp.productId
                        join c in db.Category on ctp.categoryId equals c.categoryId
                        where c.categoryId == categoryID
                        select new
                        {
                            p.productId,
                            p.name,
                            p.description,
                            p.price,
                            p.stock,
                            p.date
                        };

            return ObjTooJson.ObjToJson(query.ToList());
        }
    }

    /// <summary>
    /// Returns a LIST of PRODUCTS
    /// </summary>
    /// <param name="categoryID">CategoryID to get products from</param>
    /// <returns></returns>
    public static List<Product> GetAllProductsFromCategoryO(int categoryID)
    {
        using (var db = new EHandel())
        {
            var query = (from p in db.Product
                         join ctp in db.CategoryToProduct on p.productId equals ctp.productId
                         join c in db.Category on ctp.categoryId equals c.categoryId
                         where c.categoryId == categoryID
                         select new
                         {
                             p.productId,
                             p.name,
                             p.description,
                             p.price,
                             p.stock,
                             p.date,
                             p.isHidden
                         }).AsEnumerable()
                .Select(x => new Product()
                {
                    productId = x.productId,
                    name = x.name,
                    description = x.description,
                    price = x.price,
                    stock = x.stock,
                    date = x.date,
                    isHidden = x.isHidden
                }).ToList();

            return query;
        }
    }
    /// <summary>
    /// Return a LIST of the IMAGES for the selected PRODUCT
    /// MAKE SURE TO NOT GO OUT OF BOUNDS
    /// </summary>
    /// <param name="productID">Product ID of product</param>
    /// <returns></returns>
    public static List<Image> GetImagesForProduct(int productID)
    {
        using (var db = new EHandel())
        {
            var query = (from i in db.Image
                         where i.productId == productID
                         select new
                         {
                             i.imageId,
                             i.url,
                             i.name,
                             i.productId
                         }).AsEnumerable()
                .Select(x => new Image()
                {
                    imageId = x.imageId,
                    url = x.url,
                    name = x.name,
                    productId = x.productId

                }).ToList();
            return query;

        }
    }


    /// <summary>
    /// Get 5 Latest products added
    /// </summary>
    /// <returns></returns>
    public static List<Product> GetLatestAdded()
    {
        using (var db = new EHandel())
        {
            var query = (from p in db.Product
                         orderby p.date descending
                         select new
                         {
                             p.productId,
                             p.name,
                             p.description,
                             p.price,
                             p.stock,
                             p.date,
                             p.isHidden
                         }).AsEnumerable()
                .Select(x => new Product()
                {
                    productId = x.productId,
                    name = x.name,
                    description = x.description,
                    price = x.price,
                    stock = x.stock,
                    date = x.date,
                    isHidden = x.isHidden
                }).Take(5).ToList();

            return query;

        }
    }






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
    ///// <summary>
    ///// returns ALL products as LIST object Product
    ///// </summary>
    ///// <returns></returns>
    public static List<Product> GetAllProductsO()
    {
        using (var db = new EHandel())
        {
            var query = (from p in db.Product
                         select new
                         {
                             p.productId,
                             p.name,
                             p.description,
                             p.price,
                             p.stock,
                             p.date,
                             p.isHidden
                         }).AsEnumerable()
                .Select(x => new Product()
                {
                    productId = x.productId,
                    name = x.name,
                    description = x.description,
                    price = x.price,
                    stock = x.stock,
                    date = x.date,
                    isHidden = x.isHidden
                }).ToList();
            return query;
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
            var query = (from p in db.Product
                         select new
                         {
                             p.productId,
                             p.name,
                             p.description,
                             p.price,
                             p.stock,
                             p.date,
                             p.isHidden
                         }).AsEnumerable()
                .Select(x => new Product()
                {
                    productId = x.productId,
                    name = x.name,
                    description = x.description,
                    price = x.price,
                    stock = x.stock,
                    date = x.date,
                    isHidden = x.isHidden
                }).ToList();

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
            //Product prod = db.Product.FirstOrDefault(p => p.productId == productID);
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
    /// returns the PRODUCT OBJECT
    /// </summary>
    /// <param name="productID">ID of the product</param>
    /// <returns></returns>
    public static Product GetProductByIDo(int productID)
    {
        using (var db = new EHandel())
        {
            Product prod = db.Product.FirstOrDefault(p => p.productId == productID);

            return prod;
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
    public static int CreateCustomer(string email, string firstname, string lastname, string isAdmin, string password) //CS
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
    public static void UpdateCustomer(int userID, string email, string firstname, string lastname, string isAdmin) //Vi får eventuellt dela upp beroende på hur vi vill uppdatera kunden. CS
    {
        using (var db = new EHandel()) //använda databasen
        {
            Customer cust = db.Customer.FirstOrDefault(c => c.userId == userID); //Hitta första som matchar userID

            if (cust != null)
            {
                cust.email = email;
                cust.firstname = firstname;
                cust.lastname = lastname;
                cust.isAdmin = isAdmin;
            }
            db.SaveChanges();
        }
    }

    //Returns specific customer in Json by email //CS
    public static string GetCustomerByEmail(string email)
    {
        using (var db = new EHandel())
        {
            var query = from c in db.Customer
                        where c.email == email
                        select new
                        {
                            c.userId,
                            c.email,
                            c.firstname,
                            c.lastname,
                            c.isAdmin,
                            c.password,
                        };

            return ObjTooJson.ObjToJson(query);
        }
    }

    //Returns specific customer in Json by userId
    public static string GetCustomerByID(int userId)
    {
        using (var db = new EHandel())
        {
            var query = from c in db.Customer
                        where c.userId == userId
                        select new
                        {
                            c.userId,
                            c.email,
                            c.firstname,
                            c.lastname,
                            c.isAdmin,
                            c.password,
                        };

            return ObjTooJson.ObjToJson(query);

        }
    }

    public static string GetAllCustomers()
    {
        using (var db = new EHandel())
        {
            var query = from c in db.Customer
                        select new
                        {
                            c.userId,
                            c.email,
                            c.firstname,
                            c.lastname,
                            c.isAdmin,
                            c.password,
                        };
            return ObjTooJson.ObjToJson(query);
        }
    }

    //Updates specific product by ID
    /// <summary>
    /// Updates the product selected by productID
    /// </summary>
    /// <param name="productId">ID of product to edit</param>
    /// <param name="name">Name of product</param>
    /// <param name="description">Product description</param>
    /// <param name="price">price of product</param>
    /// <param name="stock">Stock</param>
    /// <param name="date">datetime of time when product was added</param>
    /// <param name="isHidden"> null or 0 for not hidden set to 1 to hide product</param>
    public static void UpdateProduct(int productId, string name, string description, decimal price, int stock, DateTime date, byte isHidden)
    {
        using (var db = new EHandel())
        {
            Product prod = db.Product.FirstOrDefault(p => p.productId == productId);

            if (prod != null)
            {
                prod.name = name;
                prod.description = description;
                prod.price = price;
                prod.stock = stock;
                prod.date = date;
                prod.isHidden = isHidden;
            }
            db.SaveChanges();
        }
    }

    public static string GetAllOrders()
    {
        using (var db = new EHandel())
        {
            var query = from o in db.Orders
                        select new
                        {
                            o.orderId,
                            o.date,
                            o.status,
                            o.userId,

                        };
            return ObjTooJson.ObjToJson(query);
        }
    }

    public static void UpdateCategory(int categoryId, string name)
    {
        using (var db = new EHandel())
        {
            Category cat = db.Category.FirstOrDefault(c => c.categoryId == categoryId);

            if (cat != null)
            {
                cat.name = name;
            }
            db.SaveChanges();
        }
    }

    public static void UpdateCustomerPassword(int userId, string password)
    {
        using (var db = new EHandel())
        {

            Customer cust = db.Customer.FirstOrDefault(c => c.userId == userId); //Hitta första som matchar userID

            if (cust != null)
            {
                cust.password = password;
            }
            db.SaveChanges();
        }
    }

    public static string GetAdressByUserId(int userId)
    {
        using (var db = new EHandel())
        {
            var query = from a in db.Address
                        where a.userId == userId
                        select new
                        {
                            a.addressId,
                            a.street,
                            a.zip,
                            a.city,
                            a.country,
                            a.userId,

                        };

            return ObjTooJson.ObjToJson(query);
        }
    }

    public static int CreateAddress(string street, string zip, string city, string country, int userId)
    {
        Address a = new Address
        {
            street = street,
            zip = zip,
            city = city,
            country = country,
            userId = userId,

        };

        using (var db = new EHandel())
        {
            db.Address.Add(a);
            db.SaveChanges();
        }
        return a.addressId;
    }
        //todo victor
        public static string GetAllCategoryNameFromCategoryID(int catID)
        {
            using (var db = new EHandel())
            {
                var firstOrDefault = db.Category.FirstOrDefault(c => c.categoryId == catID);
                if (firstOrDefault != null)
                {
                    string query = firstOrDefault.name;
                    return query;
                }   
                
            }
            return null;
        }
    }

}   