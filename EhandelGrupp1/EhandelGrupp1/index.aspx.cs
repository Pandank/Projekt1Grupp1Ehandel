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
                var image = DataManagement.GetImagesForProduct(product.productId);
                string productInfo = "<div class='row' id='" + product.productId + "'>";
                productInfo += "<h2 class='h2'>" + product.name + "</h2>";
                if (image.Count > 0)
                {
                    string path = image[0].url;
                    productInfo += "<img class='img-responsive' src='" + path + "' alt='' />";
                }
                else
                {
                    productInfo += "<img class='img-responsive' src='img/Papper.jpg' alt='' />";
                }
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
                var catName = DataManagement.GetAllCategoryNameFromCategoryID(int.Parse(Request["category"].ToString()));

                if (products == null) return;

                string productInfo = "<div class='row'><h2 class='h2'>KATEGORINAMN ska hämtas</h2></div>";
                productInfo += "<div class='row'";
                foreach (var product in products)
                {
                    var image = DataManagement.GetImagesForProduct(product.productId);
                    productInfo += "<div class='col-sm-3' id='" + product.productId + "'>";
                    productInfo += "<div class='thumbnail'>";
                    productInfo += "<a href='index.aspx?id=" + product.productId + "'>";
                    if (image.Count > 0)
                    {
                        string path = image[0].url;
                        productInfo += "<img class='img-responsive' src='" + path + "' alt='' />";
                    }
                    else
                    {
                        productInfo += "<img class='img-responsive' src='img/Papper.jpg' alt='' />";
                    }
                    productInfo += "<h3 class='h3'>" + product.name + "</h3>";
                    productInfo += "<p><span class='price'>" + $"{product.price:0.00}" + "</span> kr</p>";
                    productInfo += "</a>";
                    productInfo += "</div>"; // end thumbnail
                    productInfo += "</div>"; // end col-sm-3
                }
                productInfo += "</div>"; // end row
                LiteralCategory.Text = productInfo;
            }
            else
            {
                // visa startsidan
                var products = DataManagement.GetLatestAdded();

                if (products == null) return;

                string productInfo = "<div class='row'><h2 class='h2'>Nyheter</h2></div>";
                productInfo += "<div class='row'";
                foreach (var product in products)
                {
                    var image = DataManagement.GetImagesForProduct(product.productId);
                    productInfo += "<div class='col-sm-3' id='" + product.productId + "'>";
                    productInfo += "<div class='thumbnail'>";
                    productInfo += "<a href='index.aspx?id=" + product.productId + "'>";
                    if (image.Count > 0)
                    {
                        string path = image[0].url;
                        productInfo += "<img class='img-responsive' src='" + path + "' alt='' />";
                    }
                    else
                    {
                        productInfo += "<img class='img-responsive' src='img/Papper.jpg' alt='' />";
                    }
                    productInfo += "<h3 class='h3'>" + product.name + "</h3>";
                    productInfo += "<p><span class='price'>" + $"{product.price:0.00}" + "</span> kr</p>";
                    productInfo += "</a>";
                    productInfo += "</div>"; // end thumbnail
                    productInfo += "</div>"; // end col-sm-3
                }
                productInfo += "</div>"; // end row
                LiteralStart.Text += productInfo;
            }
        }
    }
}