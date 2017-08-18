using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Enterprise.Web.MPA.Models.Product;
using Enterprise.Web.MPA.Models.Filter;
namespace Enterprise.Web.MPA.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductCardModel> ProductList { get; set; }
        public List<ProductCategoryCardModel> CategoryList { get; set; }
        public List<FilterCategoryModel> FilterCategories { get; set; }
        public List<FilterProductModel> FilterProducts { get; set; }
        public IndexModel()
        {
            ProductList = FetchData();
            CategoryList = FetchCategoryData();
            FilterCategories = FetchFilterCategory();
            FilterProducts = FetchFilterProduct();
        }
        List<ProductCardModel> FetchData()
        {
            Random rand = new Random();
            List<ProductCardModel> lstProduct = new List<ProductCardModel>();
            for (int i = 0; i < 20; i++)
            {
                ProductCardModel product = new ProductCardModel
                {
                    RateStar = (decimal)(rand.NextDouble() * 5),
                    ProductName = "Product " + i,
                    Price = Math.Round(d: (decimal)rand.NextDouble() * 1000, decimals: 2),
                    Favorites = rand.Next(0, 1000),
                    Reviews = rand.Next(0, 1000)
                };
                lstProduct.Add(product);
            }
            return lstProduct;
        }
        List<ProductCategoryCardModel> FetchCategoryData()
        {
            List<ProductCategoryCardModel> items = new List<ProductCategoryCardModel>();
            for (int i = 0; i < 20; i++)
            {
                items.Add(new ProductCategoryCardModel() { CategoryName = "Category " + i });
            }
            return items;
        }
        List<FilterCategoryModel> FetchFilterCategory()
        {
            List<FilterCategoryModel> categories = new List<FilterCategoryModel>();
            for (int i = 0; i < 10; i++)
            {
                categories.Add(new FilterCategoryModel() { Category = "Category" + i, Url = "/Category/" + i });
            }
            return categories;
        }
        List<FilterProductModel> FetchFilterProduct()
        {
            List<FilterProductModel> filterProductList = new List<FilterProductModel>();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                FilterProductModel filterProductModel = new FilterProductModel();
                List<FilterModel> filterarray = new List<FilterModel>();
                for (int x = 0; x < 10; x++)
                {
                    filterarray.Add(new FilterModel
                    {
                        Checked = Math.Round((decimal)rand.NextDouble(), 0) == 1,
                        Filter = "filter " + i + " " + x
                    });
                };
                filterProductModel.Category = "Category " + i;
                filterProductModel.FilterLists = filterarray;
                filterProductList.Add(filterProductModel);
            }
            return filterProductList;
        }

        public void OnGet()
        {
        }
    }
}