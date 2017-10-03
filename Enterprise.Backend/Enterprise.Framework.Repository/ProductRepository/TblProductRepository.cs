using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.DTOs.Product;

namespace Enterprise.Framework.Repository.ProductRepository
{
    public class TblProductRepository : ProductBaseRepository<TblProduct>, ITblProductRepository
    {
        public TblProductRepository(ProductContext context) : base(context)
        {
        }
        public IEnumerable<ProductCardDTO> GetListProductCardByListString(List<string> listProductId)
        {
            var x = base._context.TblProduct.Select(y => new ProductCardDTO
            {
                ProductId = y.ProductId,
                ProductFavorite = y.ProductFavorite,
                ProductFrontImage = y.ProductFrontImage,
                ProductName = y.ProductName,
                ProductPrice = y.ProductPrice,
                ProductRating = y.ProductRating,
                ProductReview = y.ProductReview
            }).Where(z => listProductId.Contains(z.ProductId)).ToList();
            return x.AsEnumerable();
        }
        public void AddReview(string productId)
        {
            base._context.Database.ExecuteSqlCommand("EXEC dbo.sp_AddReview @productId={0}",
                productId);
        }
    }
}
