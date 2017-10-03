using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Enterprise.Core.BusinessLogics.Product.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.DataLayers.DTOs.Product;

namespace Enterprise.Core.BusinessLogics.Product
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        private readonly ITblProductRepository _productRepository;
        private readonly ICategoryBusinessLogic _categoryBusinessLogic;
        public ProductBusinessLogic(ITblProductRepository productRepository, ICategoryBusinessLogic categoryBusinessLogic)
        {
            _productRepository = productRepository;
            _categoryBusinessLogic = categoryBusinessLogic;
        }
        public TblProduct CreateProductItem(object productObject)
        {
            JObject jObject = (JObject)productObject;
            TblProduct product = new TblProduct
            {
                ProductId = Guid.NewGuid().ToString(),
                ProductName = jObject["productName"].ToString(),
                ProductFavorite = 0,
                ProductLocation = (int)jObject["productLocation"],
                ProductPrice = (decimal)jObject["productPrice"],
                ProductRating = 0,
                ProductReview = 0,
                ProductStock = (int)jObject["productStock"],
                ProductDescription = (string)jObject["productDescription"]
            };
            if (jObject["TblProductImage"] != null)
            {
                JObject[] productImage = (JObject[])jObject["TblProductImage"].ToObject(typeof(JObject[]));
                List<TblProductImage> list = new List<TblProductImage>();
                foreach (var item in productImage)
                {
                    list.Add(new TblProductImage
                    {
                        PImageId = Guid.NewGuid().ToString(),
                        Product = product,
                        ProductImageName = item["productImageName"].ToString(),
                        ProductImageUrl = item["productImageUrl"].ToString(),
                        ProductImageSize = (int)item["productImageSize"]
                    });
                }
                product.TblProductImage = list;
            }
            if (jObject["TblProductCategory"] != null)
            {
                JObject[] categories = (JObject[])jObject["TblProductCategory"].ToObject(typeof(JObject[]));
                List<TblProductCategory> list = new List<TblProductCategory>();
                foreach (var item in categories)
                {
                    list.Add(new TblProductCategory
                    {
                        Product = product,
                        PCategoryId = Guid.NewGuid().ToString(),
                        Category = _categoryBusinessLogic.GetTblCategoryByName(item["categoryName"].ToString())
                    });
                }
                product.TblProductCategory = list;
            }
            if (jObject["TblProductSpecs"] != null)
            {
                JObject[] specs = (JObject[])jObject["TblProductSpecs"].ToObject(typeof(JObject[]));
                List<TblProductSpecs> list = new List<TblProductSpecs>();
                foreach (var item in specs)
                {
                    list.Add(new TblProductSpecs
                    {
                        Product = product,
                        PSpecId = Guid.NewGuid().ToString(),
                        ProductSpecTitle = item["productSpecTitle"].ToString(),
                        ProductSpecValue = item["productSpecValue"].ToString()
                    });
                }
                product.TblProductSpecs = list;
            }
            if (jObject["TblProductVariations"] != null)
            {
                JObject[] variations = (JObject[])jObject["TblProductVariations"].ToObject(typeof(JObject[]));
                List<TblProductVariations> list = new List<TblProductVariations>();
                foreach (var item in variations)
                {
                    list.Add(new TblProductVariations
                    {
                        Product = product,
                        ProductVariation = item["productVariation"].ToString(),
                        PVariationId = Guid.NewGuid().ToString()
                    });
                }
                product.TblProductVariations = list;
            }
            return product;
        }
        public IEnumerable<TblProduct> GetAllListProduct()
        {
            return _productRepository.GetAll();
        }
        public ProductDetailsDTO GetProductDetails(string productId)
        {
            return _productRepository.GetProductDetails(productId);
        }
        public void AddReview(string productId)
        {
            _productRepository.AddReview(productId);
        }
    }
}
