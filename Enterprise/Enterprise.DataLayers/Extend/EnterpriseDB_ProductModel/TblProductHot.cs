using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Enterprise.DataLayers.Models;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProductHot
    {
        public static List<HotProductModel> GetHotProducts(Guid PeriodeId, ProductContext context)
        {
            List<HotProductModel> result = new List<HotProductModel>();
            List<TblProductHot> hotlist;

            hotlist = (from x in context.TblProductHot
                       where x.PeriodeId == PeriodeId.ToString()
                       select x).ToList();
            if (hotlist != null)
            {
                List<string> strList = new List<string>();
                foreach (var item in hotlist)
                {
                    strList.Add(item.ProductId);
                }
                result = PopulateModel(strList, context);
            }
            return result;
        }
        public static List<HotProductModel> PopulateModel(List<string> productsId, ProductContext context)
        {
            List<HotProductModel> hotlist = new List<HotProductModel>();
            List<TblProduct> products;
            products = context.TblProduct.Where(x => productsId.Contains(x.ProductId)).ToList();
            foreach (TblProduct item in products)
            {
                HotProductModel hot = new HotProductModel
                {
                    Favorites = item.ProductFavorite,
                    ProductName = item.ProductName,
                    ProductPrice = item.ProductPrice,
                    RateStar = item.ProductRating,
                    Reviews = item.ProductReview
                };
                hotlist.Add(hot);
            }
            return hotlist;
        }
    }
}
