using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Enterprise.Mobile.Views.Product;

namespace Enterprise.Mobile.Views.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCategoryCarousel : ContentView
    {
        public ProductCategoryCarousel()
        {
            InitializeComponent();
        }
        void InitCarousel()
        {
            List<ProductCategoryCard> data = FetchData();
            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 160
            };
            categoryScroll.Content = stackLayout;
            foreach (ProductCategoryCard item in data)
            {
                StackLayout productStackLayout = new StackLayout()
                {
                    WidthRequest = 100,
                    HeightRequest = 160,
                };
                productStackLayout.Children.Add(item);
                stackLayout.Children.Add(productStackLayout);
            }
        }
        List<ProductCategoryCard> FetchData()
        {
            List<ProductCategoryCard> productCategories = new List<ProductCategoryCard>();
            foreach (string item in ProductCategories)
            {
                ProductCategoryCard categoryCard = new ProductCategoryCard()
                {
                    Category = item
                };
                productCategories.Add(categoryCard);
            }
            return productCategories;
        }
        public static readonly BindableProperty ProductCategoriesProperty =
            BindableProperty.Create(
                "ProductCategories",
                typeof(List<string>),
                typeof(ProductCategoryCarousel),
                null,
                propertyChanged: (bindable, oldValue, newValue) =>
                 {
                     ProductCategoryCarousel carousel = (ProductCategoryCarousel)bindable;
                     carousel.InitCarousel();
                 });
        public List<string> ProductCategories
        {
            get
            {
                return (List<string>)GetValue(ProductCategoriesProperty);
            }
            set
            {
                SetValue(ProductCategoriesProperty, value);
            }
        }
    }
}