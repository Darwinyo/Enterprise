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
    public partial class ProductCard : ContentView
    {
        public Label ReviewLabel { get; set; }
        private List<Image> StarImages { get; set; }

        public ProductCard()
        {
            StarImages = new List<Image>();
            InitializeComponent();
        }
        void InitStars(decimal starRate)
        {
            for (int i = 1; i < 6; i++)
            {
                if (starRate >= i)
                {
                    string imagefile = GetImage(1);
                    Image img = new Image()
                    {
                        Source = Device.OnPlatform(imagefile, imagefile, "Assets/" + imagefile),
                        HeightRequest = 10,
                        WidthRequest = 10,
                        Margin = new Thickness(0,0,-6,0)
                    };
                    StarImages.Add(img);
                }
                else if (starRate > i - 1)
                {
                    string imagefile = GetImage(2);
                    Image img = new Image()
                    {
                        Source = Device.OnPlatform(imagefile, imagefile, "Assets/" + imagefile),
                        HeightRequest = 10,
                        WidthRequest = 10,
                        Margin = new Thickness(0, 0, -6, 0)
                    };
                    StarImages.Add(img);
                }
                else
                {
                    string imagefile = GetImage(3);
                    Image img = new Image()
                    {
                        Source = Device.OnPlatform(imagefile, imagefile, "Assets/" + imagefile),
                        HeightRequest = 10,
                        WidthRequest = 10,
                        Margin = new Thickness(0, 0, -6, 0)
                    };
                    StarImages.Add(img);
                }
            }
            InsertStarRate();
        }
        string GetImage(int star)
        {
            switch (star)
            {
                case 1:
                    return "fullstar.png";
                case 2:
                    return "halfstar.png";
                default:
                    return "nonestar.png";
            }
        }
        void InsertStarRate()
        {
            StackLayout starStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(-10, 0, 0, 0)
            };
            StackLayout favoriteStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                Margin=new Thickness(10,0,0,0)
            };
            Image favoriteImg = new Image()
            {
                Source = Device.OnPlatform<ImageSource>("favorite.png", "favorite.png", "Assets/favorite.png"),
                HeightRequest = 10,
                WidthRequest = 10
            };
            Label favoriteLabel = new Label()
            {
                Text = Favorite.ToString(),
                FontSize=10,
                Margin=new Thickness(-5,0,0,0)
            };
            favoriteStack.Children.Add(favoriteImg);
            favoriteStack.Children.Add(favoriteLabel);
            Grid.SetColumn(favoriteStack, 0);
            Grid.SetRow(favoriteStack, 3);
            foreach (Image item in StarImages)
            {
                starStack.Children.Add(item);
            }
            starStack.Children.Add(new Label()
            {
                Text = "(" + Reviews + ")",
                FontSize = 10
            });
            Grid.SetColumn(starStack, 1);
            Grid.SetRow(starStack, 3);
            productGrid.Children.Add(favoriteStack);
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
                     product.InitStars((decimal)newValue);
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