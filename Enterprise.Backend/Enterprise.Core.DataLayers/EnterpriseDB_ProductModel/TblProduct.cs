using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_ProductModel
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblProductCategory = new HashSet<TblProductCategory>();
            TblProductHot = new HashSet<TblProductHot>();
            TblProductImage = new HashSet<TblProductImage>();
            TblProductRecommended = new HashSet<TblProductRecommended>();
            TblProductSpecs = new HashSet<TblProductSpecs>();
            TblProductVariations = new HashSet<TblProductVariations>();
        }

        public string ProductId { get; set; }
        public int ProductFavorite { get; set; }
        public int ProductLocation { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductRating { get; set; }
        public int ProductReview { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductFrontImage { get; set; }

        public ICollection<TblProductCategory> TblProductCategory { get; set; }
        public ICollection<TblProductHot> TblProductHot { get; set; }
        public ICollection<TblProductImage> TblProductImage { get; set; }
        public ICollection<TblProductRecommended> TblProductRecommended { get; set; }
        public ICollection<TblProductSpecs> TblProductSpecs { get; set; }
        public ICollection<TblProductVariations> TblProductVariations { get; set; }
    }
}
