using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Enterprise.Mobile.Models.Product;

namespace Enterprise.Mobile.Views.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCardCarousel : ContentView
    {
        public ProductCardCarousel()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty ProductsProperty =
            BindableProperty.Create(
                "Products",
                typeof(List<ProductCardModel>),
                typeof(ProductCardCarousel),
                null,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ProductCardCarousel product = (ProductCardCarousel)bindable;
                    product.InitCarousel((List<ProductCardModel>)newValue);
                }
                );
        public List<ProductCardModel> Products
        {
            get
            {
                return (List<ProductCardModel>)GetValue(ProductsProperty);
            }
            set
            {
                SetValue(ProductsProperty, value);
            }
        }

        void InitCarousel(List<ProductCardModel> list)
        {
            if (list == null)
                return;
            StackLayout stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 210
            };
            productCardScroll.Content = stack;

            
            foreach (ProductCardModel item in list)
            {
                StackLayout stackCard = new StackLayout
                {
                    WidthRequest = 180,
                    HeightRequest = 210
                };
                ProductCard card = new ProductCard();
                card.ProductName = item.ProductName;
                card.Price = item.Price;
                card.Favorite = item.Favorites;
                card.Reviews = item.Reviews;
                card.StarRating = item.StarRate;
                stackCard.Children.Add(card);
                stack.Children.Add(stackCard);
            }
        }
    }
}