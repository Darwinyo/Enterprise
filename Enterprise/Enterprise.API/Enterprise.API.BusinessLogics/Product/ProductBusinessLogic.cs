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
                ProductFavorite = (int)jObject["productFavorite"],
                ProductLocation = (int)jObject["productLocation"],
                ProductPrice = (decimal)jObject["productPrice"],
                ProductRating = (decimal)jObject["productRating"],
                ProductReview = (int)jObject["productReview"],
                ProductStock = (int)jObject["productStock"],
                ProductDescription = (string)jObject["productDescription"]
            };
            if (jObject["productImages"] != null)
            {
                List<byte[]> productImage = (List<byte[]>)jObject["productImages"].ToObject(typeof(List<byte[]>));
                List<TblProductImage> list = new List<TblProductImage>();
                foreach (var item in productImage)
                {
                    list.Add(new TblProductImage
                    {
                        PImageId = Guid.NewGuid().ToString(),
                        Product=product,
                        ProductImageUrl = item
                    });
                }
                product.TblProductImage = list;
            }
            if (jObject["productCategory"] != null)
            {
                List<string> categories = (List<string>)jObject["productCategory"].ToObject(typeof(string));
                List<TblProductCategory> list = new List<TblProductCategory>();
                foreach (string item in categories)
                {
                    list.Add(new TblProductCategory
                    {
                        Product = product,
                        PCategoryId = Guid.NewGuid().ToString(),
                        Category = CategoryBusinessLogic.GetTblCategoryByName(item, context)
                    });
                }
                product.TblProductCategory = list;
            }
            if (jObject["productSpecs"] != null)
            {
                List<string[]> specs = (List<string[]>)jObject.ToObject(typeof(List<string[]>));
                List<TblProductSpecs> list = new List<TblProductSpecs>();
                foreach (string[] item in specs)
                {
                    list.Add(new TblProductSpecs
                    {
                        Product = product,
                        PSpecId = Guid.NewGuid().ToString(),
                        ProductSpecTitle = item[0],
                        ProductSpecValue = item[1]
                    });
                }
                product.TblProductSpecs = list;
            }
            if (jObject["productVariations"] != null)
            {
                List<string> variations = (List<string>)jObject["productVariations"].ToObject(typeof(List<string>));
                List<TblProductVariations> list = new List<TblProductVariations>();
                foreach (string item in variations)
                {
                    list.Add(new TblProductVariations
                    {
                        Product = product,
                        ProductVariation = item,
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
        public static PM.TblProduct GetListProductById(string ProductId,PM.ProductContext context)
        {
            return PM.TblProduct.GetListProductById(ProductId, context);
        }
    }
}
