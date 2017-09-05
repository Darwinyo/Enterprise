using System;
using System.Collections.Generic;
using System.Text;
using PM = Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.API.BusinessLogics.Product
{
    public class ProductBusinessLogic
    {
        public static bool AddNewProduct(object obj, PM.ProductContext context)
        {
            if (obj == null)
                return false;
            else
            {
                JObject jObject = (JObject)obj;
                TblProduct product=CreateProductItem(jObject, context);
                if (PM.TblProduct.AddNewProduct(product, context) != 0)
                    return true;
                return false;
            }
            
        }
        public static TblProduct CreateProductItem(JObject jObject,ProductContext context)
        {
            PM.TblProduct product = new PM.TblProduct
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
                        Product=product,
                        ProductImageName=item["productImageName"].ToString(),
                        ProductImageUrl = item["productImageUrl"].ToString(),
                        ProductImageSize=(int)item["productImageSize"]
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
                        Category = CategoryBusinessLogic.GetTblCategoryByName(item["categoryName"].ToString(), context)
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
        public static List<PM.TblProduct> GetAllListProduct(PM.ProductContext context)
        {
            return PM.TblProduct.GetAllListProduct(context);
        }
        public static PM.TblProduct GetProductById(string ProductId,PM.ProductContext context)
        {
            return PM.TblProduct.GetProductById(ProductId, context);
        }
    }
}
