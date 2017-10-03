using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.DataLayers.DTOs.Product;
using Enterprise.Core.DataLayers.DTOs.Models.Product;

namespace Enterprise.Core.Repository.ProductRepository
{
    public class TblProductRepository : ProductBaseRepository<TblProduct>, ITblProductRepository
    {
        public TblProductRepository(ProductContext context) : base(context)
        {
        }
        public ProductDetailsDTO GetProductDetails(string productId)
        {
            return _context.TblProduct.Where(x => x.ProductId == productId).Select(x => new ProductDetailsDTO
            {
                ProductFavorite = x.ProductFavorite,
                ProductDescription = x.ProductDescription,
                ProductLocation=x.ProductLocation,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductRating = x.ProductRating,
                ProductReview = x.ProductReview,
                ProductStock = x.ProductStock,
                ProductImages = x.TblProductImage.Select(y => new ProductImage
                {
                    PImageId = y.PImageId,
                    ProductImageName = y.ProductImageName,
                    ProductImageSize = y.ProductImageSize,
                    ProductImageUrl = y.ProductImageUrl
                }),
                ProductSpecs = x.TblProductSpecs.Select(y => new ProductSpec
                {
                    ProductSpecTitle = y.ProductSpecTitle,
                    ProductSpecValue = y.ProductSpecValue,
                    PSpecId = y.PSpecId
                }),
                ProductVariations = x.TblProductVariations.Select(y => new ProductVariationItem
                {
                    ProductVariation = y.ProductVariation,
                    PVariationId = y.PVariationId
                })
            }).FirstOrDefault();
        }
        public IEnumerable<TblProduct> GetListProductByListString(List<string> listProductId)
        {
            var x = base._context.TblProduct.Where(z => listProductId.Contains(z.ProductId)).ToList();
            x.ForEach(z =>
            {
                z.TblProductHot = null;
                z.TblProductRecommended = null;
            });
            return x.AsEnumerable();
        }
        public void AddReview(string productId)
        {
            base._context.Database.ExecuteSqlCommand("EXEC dbo.sp_AddReview @productId={0}",
                productId);
        }
    }
}
