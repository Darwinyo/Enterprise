using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Enterprise.Mobile.Models.ProductDetails;

namespace Enterprise.Mobile.Views.ProductDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailDescription : ContentView
    {
        public ProductDetailDescription()
        {
            InitializeComponent();
        }
        #region properties
        public string DescriptionTitle
        {
            get
            {
                return (string)GetValue(DescriptionTitleProperty);
            }
            set
            {
                SetValue(DescriptionTitleProperty, value);
            }
        }
        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }
            set
            {
                SetValue(DescriptionProperty, value);
            }
        }
        public List<ProductSpecsModel> ProductSpecs
        {
            get
            {
                return (List<ProductSpecsModel>)GetValue(ProductSpecsProperty);
            }
            set
            {
                SetValue(ProductSpecsProperty, value);
            }
        }
        #endregion
        #region fields
        public static readonly BindableProperty DescriptionTitleProperty =
            BindableProperty.Create(
                "DescriptionTitle",
                typeof(string),
                typeof(ProductDetailDescription),
                null);
        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
                "Description",
                typeof(string),
                typeof(ProductDetailDescription),
                null);
        public static readonly BindableProperty ProductSpecsProperty =
            BindableProperty.Create(
                "ProductSpecs",
                typeof(List<ProductSpecsModel>),
                typeof(ProductDetailDescription),
                null);
#endregion
    }
}