using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enterprise.Mobile.Views.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCategoryCarouselView : ContentView
    {
        public ProductCategoryCarouselView()
        {
            InitializeComponent();
        }
        void InitData()
        {
            Content = new ProductCategoryCarousel()
            {
                ProductCategories = CategoryList
            };
        }
        public static readonly BindableProperty CategoryListProperty =
            BindableProperty.Create(
                "CategoryList",
                typeof(List<string>),
                typeof(ProductCategoryCarouselView),
                null,
                propertyChanged:(bindable,oldValue,newValue)=> {
                    ProductCategoryCarouselView view = (ProductCategoryCarouselView)bindable;
                    view.InitData();
                });
        public List<string> CategoryList
        {
            get
            {
                return (List<string>)GetValue(CategoryListProperty);
            }
            set
            {
                SetValue(CategoryListProperty, value);
            }
        }
    }
}