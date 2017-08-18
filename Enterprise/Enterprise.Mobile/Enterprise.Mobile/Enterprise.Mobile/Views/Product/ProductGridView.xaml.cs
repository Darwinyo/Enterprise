using Enterprise.Models.Product;
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
    public partial class ProductGridView : ContentView
    {
        public ProductGridView()
        {
            InitializeComponent();
        }
        void InitPage(double colWidth)
        {
            stackLayout.Children.Clear();
            Grid grid = new Grid();
            int cols = (int)Math.Floor(colWidth / 180);
            ColumnDefinition def = new ColumnDefinition()
            {
                Width = new GridLength(180)
            };
            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(def);
            }
            List<ProductCardModel> lstproduct = InitData();

            int rows = (int)Math.Ceiling((double)lstproduct.Count() / cols);
            RowDefinition rowdef = new RowDefinition()
            {
                Height = GridLength.Auto
            };
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(rowdef);
            }
            int productCount = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (productCount < lstproduct.Count())
                    {
                        ProductCard pview = new ProductCard();
                        pview.ProductName = lstproduct[productCount].ProductName;
                        pview.Price = lstproduct[productCount].Price;
                        pview.Favorite = lstproduct[productCount].Favorites;
                        pview.Reviews = lstproduct[productCount].Reviews;
                        pview.StarRating = lstproduct[productCount].StarRate;
                        Grid.SetColumn(pview, x);
                        Grid.SetRow(pview, i);
                        grid.Children.Add(pview);
                        productCount++;
                    }
                    else if (productCount == lstproduct.Count())
                    {
                        // store last row & col
                        Application.Current.Properties["LastRow"] = i;
                        Application.Current.Properties["LastCol"] = x;
                        Application.Current.Properties["WidthScreen"] = colWidth;
                        break;
                    }
                }
            }
            stackLayout.Children.Add(grid);
        }
        List<ProductCardModel> InitData()
        {
            return ListProductCard;
        }
        public static readonly BindableProperty ListProductCardProperty =
            BindableProperty.Create(
                "ListProductCard",
                typeof(List<ProductCardModel>),
                typeof(ProductGridView),
                null,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    // FOR UPDATE GRID => NEW VALUES

                    //ProductGridView grid = new ProductGridView();
                    //grid.InitPage((double)Application.Current.Properties["WidthScreen"]);
                });
        public List<ProductCardModel> ListProductCard
        {
            get
            {
                return (List<ProductCardModel>)GetValue(ListProductCardProperty);
            }
            set
            {
                SetValue(ListProductCardProperty, value);
            }
        }

        private void ContentView_SizeChanged(object sender, EventArgs e)
        {
            IDictionary<string, object> properties = Application.Current.Properties;
            if (properties.ContainsKey("WidthScreen"))
            {
                if (!properties["WidthScreen"].Equals(Width))
                    InitPage(Width);
            }
            else
            {
                InitPage(Width);

            }
        }
    }
}