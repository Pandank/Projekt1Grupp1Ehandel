using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EhandelGrupp1;
using Newtonsoft.Json;

namespace EhandelGrupp1.services
{
    public partial class svc_createcustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["userId"]))
            {
                // Kolla så all data finns
                string email = !string.IsNullOrEmpty(Request["email"]) ? Request["email"] : "";
                int userID = !string.IsNullOrEmpty(Request["userId"]) ? int.Parse(Request["userId"]) : 0;
                string firstName = !string.IsNullOrEmpty(Request["firstname"]) ? Request["firstname"] : "";
                string lastName = !string.IsNullOrEmpty(Request["lastname"]) ? Request["lastname"] : "";
                string isAdmin = !string.IsNullOrEmpty(Request["isAdmin"]) ? Request["isAdmin"] : "";
                string passWord = !string.IsNullOrEmpty(Request["password"]) ? Request["password"] : "";

                //string street = !string.IsNullOrEmpty(Request["street"]) ? Request["street"] : "";
                //string zip = !string.IsNullOrEmpty(Request["zip"]) ? Request["zip"] : "";
                //string city= !string.IsNullOrEmpty(Request["city"]) ? Request["city"] : "";
                //string country = !string.IsNullOrEmpty(Request["country"]) ? Request["country"] : "";
                

                if (userID > 0 && email.Length > 0 && firstName.Length > 0 && lastName.Length > 0 && isAdmin.Length > 0)
                {
                    DataManagement.CreateCustomer(email, firstName, lastName, isAdmin, passWord);

                    LiteralCreateCustomer.Text = JsonConvert.SerializeObject("Ok");

                    //DataManagement.CreateAddress(street, zip, city, country, userID);

                    //LiteralCreateAddress.Text = JsonConvert.SerializeObject("Ok");


                }
                else
                {
                    LiteralCreateCustomer.Text = JsonConvert.SerializeObject("Error");
                }
            }
        }
    }
}