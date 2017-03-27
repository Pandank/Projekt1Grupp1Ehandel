﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EhandelGrupp1.EF;
using Newtonsoft.Json;

namespace EhandelGrupp1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                // visa produkt
                var product = DataManagement.GetProductByIDo(int.Parse(Request["id"].ToString()));

                string productInfo = "<div class='row' id='" + product.productId + "'>";
                productInfo += "<h2 class='h2'>" + product.name + "</h2>";
                productInfo += "<img class='img-responsive' src='img/Papper.jpg' alt='' />";
                productInfo += "<p><span class='price'>" + product.price + "</span> kr</p>";
                productInfo += "<input type='number' value='1' id='itemCounter' />";
                productInfo += "<button type='button' class='btn btn-primary addToCartButton'>Köp</button>";
                productInfo += "<div class='productDescription'><p>" + product.description + "</p></div>";
                productInfo += "</div>"; // end row
                // skriv ut produkt
                LiteralProduct.Text = productInfo;
            }
            else if (!string.IsNullOrEmpty(Request["category"]))
            {
                // visa alla produkter i given kategori
                var products = DataManagement.GetAllProductsFromCategoryO(int.Parse(Request["category"].ToString()));
                //string name;
                foreach (var product in products)
                {
                    LiteralCategory.Text += product.name;
                }
                
            }
            else
            {
                // visa startsidan
                var products = DataManagement.GetAllProducts();             
                LiteralStart.Text = products;
            }
        }
    }
}