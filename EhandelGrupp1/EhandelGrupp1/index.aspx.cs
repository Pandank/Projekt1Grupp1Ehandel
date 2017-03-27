using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EhandelGrupp1.EF;
using Newtonsoft.Json;

namespace EhandelGrupp1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                // visa produkt
                var product = DataManagement.GetProductByIDo(int.Parse(Request["id"]));

                if (product == null) return;

                string productInfo = "<div class='row' id='" + product.productId + "'>";
                productInfo += "<h2 class='h2'>" + product.name + "</h2>";
                productInfo += "<img class='img-responsive' src='img/Papper.jpg' alt='' />";
                productInfo += "<p><span class='price'>" + $"{product.price:0.00}" + "</span> kr</p>";
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

                if (products == null) return;

                string productInfo = "<h2 class='h2'>KATEGORINAMN ska hämtas</h2>";
                foreach (var product in products)
                {
                    productInfo += "<div class='row' id='" + product.productId + "'>";
                    productInfo += "<h3 class='h3'>" + product.name + "</h3>";
                    productInfo += "<img class='img-responsive' src='img/Papper.jpg' alt='' />";
                    productInfo += "<p><span class='price'>" + $"{product.price:0.00}" + "</span> kr</p>";
                    productInfo += "</div>"; // end row
                }
                LiteralCategory.Text = productInfo;
            }
            else
            {
                // visa startsidan
                var products = DataManagement.GetLatestAdded();

                if (products == null) return;

                string productInfo = "<h2 class='h2'>Nyheter</h2>";
                foreach (var product in products)
                {
                    productInfo += "<div class='row' id='" + product.productId + "'>";
                    productInfo += "<h3 class='h3'>" + product.name + "</h3>";
                    productInfo += "<img class='img-responsive' src='img/Papper.jpg' alt='' />";
                    productInfo += "<p><span class='price'>" + $"{product.price:0.00}" + "</span> kr</p>";
                    productInfo += "</div>"; // end row
                }
                LiteralStart.Text += productInfo;
            }
        }
    }
}