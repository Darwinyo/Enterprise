using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enterprise.Mobile.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductSpecsCell : ViewCell
    {
        public ProductSpecsCell()
        {
            InitializeComponent();
        }
        #region properties
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        public string ItemValue
        {
            get
            {
                return (string)GetValue(ItemValueProperty);
            }
            set
            {
                SetValue(ItemValueProperty, value);
            }
        }
        #endregion
        #region fields
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(
                "Title",
                typeof(string),
                typeof(ProductSpecsCell),
                null);
        public static readonly BindableProperty ItemValueProperty =
            BindableProperty.Create(
                "ItemValue",
                typeof(string),
                typeof(ProductSpecsCell),
                null);
        #endregion
    }
}