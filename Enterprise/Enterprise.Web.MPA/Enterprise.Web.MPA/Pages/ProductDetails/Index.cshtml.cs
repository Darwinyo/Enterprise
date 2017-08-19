using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Enterprise.Web.MPA.Models.ProductDetail;
using Enterprise.Web.MPA.BusinessLogics.StarRate;

namespace Enterprise.Web.MPA.Pages.ProductDetails
{
    public class IndexModel : PageModel
    {
        public ProductDetailContentModel ProductDetail { get; set; }
        public ProductDetailImageModel ProductImages { get; set; }
        public ProductDetailDescriptionComponentModel ProductDescription { get; set; }
        public IndexModel()
        {
            FetchProduct();
        }
        void FetchProduct()
        {
            ProductDetail = new ProductDetailContentModel
            {
                Location = "Shanghai",
                Price = 2000,
                ProductName = "CPU",
                RateStar = 4,
                Reviews = 1000,
                Stock = 1020,
                Variations = new List<string> { "Black", "White", "Blue", "Red" },
                Favorites = 1231,
                Delivery= "Beijing",
                DeliveryPrice=100,
                DeliveryOptions=new List<string> { "JNE", "Cargo", "Airplane" },
                Locations=new List<string> { "Beijing", "Shanghai", "Xiamen", "Suzhou", "Nanjing", "Hongkong", "Taiwan", "HeiLongJiang", "GuangZhou" }
            };
            ProductImages = new ProductDetailImageModel
            {
                ImagesGalery = new List<string>
                {
                    "/images/product/ryzen5.jpeg",
                    "/images/product/inteli7.jpeg",
                    "/images/product/inteli7.jpeg",
                    "/images/product/inteli7.jpeg"
                }
            };
            ProductDescription = new ProductDetailDescriptionComponentModel
            {
                Description = "Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit. Mauris rutrum volutpat massa," +
                " sed tincidunt tortor facilisis id. Duis magna nisl, mollis quis convallis vel," +
                " ornare nec orci. Nunc id ultricies ligula. Integer purus purus, tempor a accumsan gravida, " +
                "laoreet vel justo. Etiam feugiat dolor dolor, in mattis nulla gravida sed. Nulla ut felis nulla." +
                " Fusce malesuada orci eu velit sollicitudin commodo. Praesent quis est at lorem mattis tincidunt." +
                " Vivamus non velit eget urna euismod viverra in aliquet enim.Nunc ligula est, imperdiet eget neque vitae," +
                " semper vestibulum quam.Phasellus vehicula faucibus urna," +
                " eget consequat est pharetra quis.Morbi in dolor in tortor vulputate pharetra a non velit.Nullam nec erat" +
                " a ante pharetra feugiat non tempus est.Maecenas fringilla semper mauris eget porta.Suspendisse eu purus" +
                " lacinia, laoreet urna at, fermentum arcu.Integer mollis massa felis, sit amet pharetra velit imperdiet sed." +
                "Duis sit amet porttitor felis.Nam urna libero, luctus in mollis sit amet, vestibulum vel lorem.Vestibulum pharetra" +
                " aliquam ipsum vel maximus.Etiam sit amet metus ut est porttitor ornare id a lorem.Ut vitae justo nec orci sollicitudin" +
                " malesuada sed sed sem.Donec ut erat viverra turpis egestas condimentum in ut tellus.Pellentesque habitant morbi tristique" +
                " senectus et netus et malesuada fames ac turpis egestas.Vestibulum imperdiet quis justo eget ultrices.Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit.Donec pretium a augue ac interdum.Maecenas leo velit, vulputate vitae ligula id," +
                " blandit bibendum metus.Cras rhoncus ligula eu ex bibendum consectetur.Praesent id nisi tristique, commodo mi sodales," +
                " gravida erat.Donec pulvinar molestie vulputate.Suspendisse tincidunt blandit mauris vel malesuada.Ut tempus quam vitae " +
                "ultrices rutrum.Nullam facilisis facilisis condimentum.Sed sit amet diam a urna vulputate lobortis.Morbi in convallis dolor." +
                "Cras congue arcu nunc, vel venenatis lacus lacinia nec.Proin rhoncus nibh id feugiat aliquet.Donec vel aliquam ante.Suspendisse" +
                " non ultrices lectus.Morbi augue libero, aliquam a libero sit amet, faucibus rhoncus sem.Curabitur sit amet pharetra est, eu tristique" +
                " nisi.In varius commodo urna.Duis non ipsum laoreet, facilisis erat sed, faucibus turpis.Maecenas urna dolor, blandit a nunc ut, auctor " +
                "bibendum dolor.Donec sit amet ipsum quam.Proin vitae quam at ante fringilla fermentum.",
                DetailsProduct = new List<ProductItemSpecsModel>
                {
                    new ProductItemSpecsModel
                    {
                        Title="Category'",
                        Value="Computer Parts"
                    },
                    new ProductItemSpecsModel
                    {
                        Title="Dimension'",
                        Value="20x20x20"
                    },
                    new ProductItemSpecsModel
                    {
                        Title="Condition'",
                        Value="New"
                    },
                    new ProductItemSpecsModel
                    {
                        Title="Manufacturer'",
                        Value="Intel/AMD"
                    },
                }
            };
        }
        public void OnGet()
        {
        }
    }
}