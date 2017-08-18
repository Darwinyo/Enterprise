using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Enterprise.Models.Product;
namespace Enterprise.Mobile.Views.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCardCarouselView : ContentView
    {
        public ProductCardCarouselView()
        {
            InitializeComponent();
        }
        void InitData()
        {
            Content = new ProductCardCarousel
            {
                Products = ProductList
            };
        }
        public static readonly BindableProperty ProductListProperty =
            BindableProperty.Create(
                "ProductList",
                typeof(List<ProductCardModel>),
                typeof(ProductCardCarouselView),
                null,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ProductCardCarouselView view = (ProductCardCarouselView)bindable;
                    view.InitData();
                });
        public List<ProductCardModel> ProductList
        {
            get
            {
                return (List<ProductCardModel>)GetValue(ProductListProperty);
            }
            set
            {
                SetValue(ProductListProperty, value);
            }
        }

    }
}