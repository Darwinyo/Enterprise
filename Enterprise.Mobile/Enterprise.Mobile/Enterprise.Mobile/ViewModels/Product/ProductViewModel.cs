using Enterprise.Mobile.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Enterprise.Mobile.ViewModels.Product
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
        {
            ListProduct = InitDataProductCard();
            HotProductList = ListProduct;
            CategoryList = InitProductCategory();
        }
        List<string> categoryList;
        List<ProductCardModel> listProduct, hotProductList;
        public List<string> CategoryList
        {
            get
            {
                return categoryList;
            }
            set
            {
                SetProperty(ref categoryList, value);
            }
        }
        public List<ProductCardModel> ListProduct
        {
            get
            {
                return listProduct;
            }
            set
            {
                SetProperty(ref listProduct, value);
            }
        }
        public List<ProductCardModel> HotProductList
        {
            get
            {
                return hotProductList;
            }
            set
            {
                SetProperty(ref hotProductList, value);
            }
        }

        List<ProductCardModel> InitDataProductCard()
        {
            Random rand = new Random();
            List<ProductCardModel> lstProduct = new List<ProductCardModel>();
            for (int i = 0; i < 20; i++)
            {
                ProductCardModel product = new ProductCardModel
                {
                    StarRate = (decimal)(rand.NextDouble() * 5),
                    ProductName = "Product " + i,
                    Price = Math.Round(d: (decimal)rand.NextDouble() * 1000, decimals: 2),
                    Favorites = rand.Next(0, 1000),
                    Reviews = rand.Next(0, 1000)
                };
                lstProduct.Add(product);
            }
            return lstProduct;
        }
        List<string> InitProductCategory()
        {
            List<string> categories = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                categories.Add("Category " + i);
            }
            return categories;
        }
    }
}
