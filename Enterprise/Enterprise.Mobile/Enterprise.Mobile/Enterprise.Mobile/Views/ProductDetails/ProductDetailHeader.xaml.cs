using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Enterprise.Mobile.Helpers.StarRate;

namespace Enterprise.Mobile.Views.ProductDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailHeader : ContentView
    {
        public ProductDetailHeader()
        {
            InitializeComponent();
        }
        #region fields
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(
                "Title",
                typeof(string),
                typeof(ProductDetailHeader),
                null);
        public static readonly BindableProperty PriceProperty =
            BindableProperty.Create(
                "Price",
                typeof(decimal),
                typeof(ProductDetailHeader),
                (decimal)0);
        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(
                "Rating",
                typeof(decimal),
                typeof(ProductDetailHeader),
                (decimal)0,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ProductDetailHeader prod = (ProductDetailHeader)bindable;
                    prod.InsertStars();
                });
        public static readonly BindableProperty ReviewProperty =
            BindableProperty.Create(
                "Review",
                typeof(int),
                typeof(ProductDetailHeader),
                0);
        public static readonly BindableProperty ProductLocationProperty =
            BindableProperty.Create(
                "ProductLocation",
                typeof(string),
                typeof(ProductDetailHeader),
                null);
        public static readonly BindableProperty ShippingProperty =
            BindableProperty.Create(
                "Shipping",
                typeof(string),
                typeof(ProductDetailHeader),
                null);
        public static readonly BindableProperty ShippingPriceProperty =
            BindableProperty.Create(
                "ShippingPrice",
                typeof(decimal),
                typeof(ProductDetailHeader),
                (decimal)0);
        public static readonly BindableProperty FavoriteProperty =
            BindableProperty.Create(
                "Favorite",
                typeof(int),
                typeof(ProductDetailHeader),
                0);
        #endregion
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
        public decimal Price
        {
            get
            {
                return (decimal)GetValue(PriceProperty);
            }
            set
            {
                SetValue(PriceProperty, value);
            }
        }
        public decimal Rating
        {
            get
            {
                return (decimal)GetValue(RatingProperty);
            }
            set
            {
                SetValue(RatingProperty, value);
            }
        }
        public int Review
        {
            get
            {
                return (int)GetValue(ReviewProperty);
            }
            set
            {
                SetValue(ReviewProperty, value);
            }
        }
        public string ProductLocation
        {
            get
            {
                return (string)GetValue(ProductLocationProperty);
            }
            set
            {
                SetValue(ProductLocationProperty, value);
            }
        }
        public string Shipping
        {
            get
            {
                return (string)GetValue(ShippingProperty);
            }
            set
            {
                SetValue(ShippingProperty, value);
            }
        }
        public decimal ShippingPrice
        {
            get
            {
                return (decimal)GetValue(ShippingPriceProperty);
            }
            set
            {
                SetValue(ShippingPriceProperty, value);
            }
        }
        public int Favorite
        {
            get
            {
                return (int)GetValue(FavoriteProperty);
            }
            set
            {
                SetValue(FavoriteProperty, value);
            }
        }
        #endregion
        void InsertStars()
        {
            List<Image> stars = StarRateHelper.InitProductDetailStars(Rating);
            Label starLabel = new Label()
            {
                Text = string.Format("{0}/5", Rating.ToString())
            };
            StackLayout StarStack = StarRateHelper.CreateProductDetailStarStack(stars);
            Label reviewLabel = new Label()
            {
                Text = string.Format("({0})", Review.ToString())
            };
            Grid.SetColumn(StarStack, 0);
            Grid.SetColumn(starLabel, 1);
            Grid.SetColumn(reviewLabel, 2);
            Grid grid = new Grid()
            {
                ColumnDefinitions = {
                    new ColumnDefinition(){ Width=GridLength.Auto},
                    new ColumnDefinition() { Width = GridLength.Auto },
                    new ColumnDefinition() { Width = GridLength.Auto }
                }
            };
            grid.Children.Add(StarStack);
            grid.Children.Add(starLabel);
            grid.Children.Add(reviewLabel);
            stackStar.Children.Add(grid);
        }
    }
}