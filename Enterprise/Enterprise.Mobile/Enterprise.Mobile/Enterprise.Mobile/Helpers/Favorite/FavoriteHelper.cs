using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Enterprise.Mobile.Helpers.Favorite
{
    public class FavoriteHelper
    {
        public static StackLayout CreateFavoriteStack(int Favorite)
        {
            StackLayout favoriteStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(10, 0, 0, 0)
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
                FontSize = 10,
                Margin = new Thickness(-5, 0, 0, 0)
            };
            favoriteStack.Children.Add(favoriteImg);
            favoriteStack.Children.Add(favoriteLabel);
            return favoriteStack;
        }
    }
}
