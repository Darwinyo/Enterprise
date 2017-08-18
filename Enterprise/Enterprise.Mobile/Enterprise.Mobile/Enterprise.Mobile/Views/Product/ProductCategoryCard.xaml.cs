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
    public partial class ProductCategoryCard : ContentView
    {
        public ProductCategoryCard()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty CategoryProperty =
            BindableProperty.Create(
                "Category",
                typeof(string),
                typeof(ProductCategoryCard),
                "");
        public string Category
        {
            get
            {
                return (string)GetValue(CategoryProperty);
            }
            set
            {
                SetValue(CategoryProperty, value);
            }
        }
    }
}