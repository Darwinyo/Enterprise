using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Web.MPA.BusinessLogics.StarRate
{
    public class StarRateBusinessLogic
    {
        public static string[] InitStars(decimal rateStar)
        {
            string[] stars = new string[6];
            for (int i = 1; i < 6; i++)
            {
                if (rateStar >= i)
                {
                    stars[i] = "/images/icons/fullstar.png";
                }
                else if (rateStar > (i - 1))
                {
                    stars[i] = "/images/icons/halfstar.png";
                }
                else
                {
                    stars[i] = "/images/icons/nonestar.png";
                }
            }
            return stars;
        }
    }
}
