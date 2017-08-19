using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Mobile.BusinessLogics.StarRate
{
    public partial class StarRateBusinessLogic
    {
        public string GetImage(int star)
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
