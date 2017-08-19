using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Enterprise.Mobile.Helpers.StarRate
{
    public class StarRateHelper
    {
        public static List<Image> InitStars(decimal starRate)
        {
            List<Image> StarImages = new List<Image>();
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
                        Margin = new Thickness(0, 0, -6, 0)
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
            return StarImages;
        }
        public static List<Image> InitProductDetailStars(decimal starRate)
        {
            List<Image> StarImages = new List<Image>();
            for (int i = 1; i < 6; i++)
            {
                if (starRate >= i)
                {
                    string imagefile = GetImage(1);
                    Image img = new Image()
                    {
                        Source = Device.OnPlatform(imagefile, imagefile, "Assets/" + imagefile),
                        HeightRequest = 15,
                        WidthRequest = 15,
                        Margin = new Thickness(0, 0, -6, 0)
                    };
                    StarImages.Add(img);
                }
                else if (starRate > i - 1)
                {
                    string imagefile = GetImage(2);
                    Image img = new Image()
                    {
                        Source = Device.OnPlatform(imagefile, imagefile, "Assets/" + imagefile),
                        HeightRequest = 15,
                        WidthRequest = 15,
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
                        HeightRequest = 15,
                        WidthRequest = 15,
                        Margin = new Thickness(0, 0, -6, 0)
                    };
                    StarImages.Add(img);
                }
            }
            return StarImages;
        }
        public static StackLayout CreateStarStack(List<Image> stars)
        {
            StackLayout starStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(-10, 0, 0, 0)
            };
            foreach (Image item in stars)
            {
                starStack.Children.Add(item);
            }
            return starStack;
        }
        public static StackLayout CreateProductDetailStarStack(List<Image> stars)
        {
            StackLayout starStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
            };
            foreach (Image item in stars)
            {
                starStack.Children.Add(item);
            }
            return starStack;
        }
        static string GetImage(int star)
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
    }
}
