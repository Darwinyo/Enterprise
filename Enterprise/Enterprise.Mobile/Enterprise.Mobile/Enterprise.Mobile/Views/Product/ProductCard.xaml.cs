using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Enterprise.Mobile.Helpers.StarRate;
using Enterprise.Mobile.Helpers.Favorite;

namespace Enterprise.Mobile.Views.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCard : ContentView
    {
        public Label ReviewLabel { get; set; }
        private List<Image> StarImages { get; set; }

        public ProductCard()
        {
            StarImages = new List<Image>();
            InitializeComponent();
        }
        void PopulateStars(decimal starRate)
        {
            StarImages = StarRateHelper.InitStars(starRate);
            InsertStarRate();
            InsertFavorites();
        }
        
        void InsertFavorites()
        {
            StackLayout favoriteStack= FavoriteHelper.CreateFavoriteStack(Favorite);
            Grid.SetColumn(favoriteStack, 0);
            Grid.SetRow(favoriteStack, 3);
            productGrid.Children.Add(favoriteStack);
        }
        void InsertStarRate()
        {
            StackLayout starStack = StarRateHelper.CreateStarStack(StarImages);
            starStack.Children.Add(new Label()
            {
                Text = "(" + Reviews + ")",
                FontSize = 10
            });
            Grid.SetColumn(starStack, 1);
            Grid.SetRow(starStack, 3);
            productGrid.Children.Add(starStack);
        }

        public static readonly BindableProperty ProductNameProperty =
            BindableProperty.Create(
                "ProductName",
                typeof(string),
                typeof(ProductCard),
                "");
        public static readonly BindableProperty PriceProperty =
            BindableProperty.Create(
                "Price",
                typeof(decimal),
                typeof(ProductCard),
                0m);
        public static readonly BindableProperty FavoriteProperty =
            BindableProperty.Create(
                "Favorite",
                typeof(int),
                typeof(ProductCard),
                0);
        public static readonly BindableProperty StarRatingProperty =
            BindableProperty.Create(
                "StarRating",
                typeof(decimal),
                typeof(ProductCard),
                (decimal)0,
                propertyChanged: (bindable, oldValue, newValue) =>
                 {
                     ProductCard product = (ProductCard)bindable;
                     product.PopulateStars((decimal)newValue);
                 });
        public static readonly BindableProperty ReviewsProperty =
            BindableProperty.Create(
                "Reviews",
                typeof(int),
                typeof(ProductCard),
                0);

        public string ProductName
        {
            get
            {
                return (string)GetValue(ProductNameProperty);
            }
            set
            {
                SetValue(ProductNameProperty, value);
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
        public decimal StarRating
        {
            get
            {
                return (decimal)GetValue(StarRatingProperty);
            }
            set
            {
                SetValue(StarRatingProperty, value);
            }
        }
        public int Reviews
        {
            get
            {
                return (int)GetValue(ReviewsProperty);
            }
            set
            {
                SetValue(ReviewsProperty, value);
            }
        }
    }
}