using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.BusinessLogics.Product;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.BusinessLogics.Product
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        private readonly ITblProductRepository _productRepository;
        private readonly ICategoryBusinessLogic _categoryBusinessLogic;
        public ProductBusinessLogic(ITblProductRepository productRepository,ICategoryBusinessLogic categoryBusinessLogic)
        {
            _productRepository = productRepository;
            _categoryBusinessLogic = categoryBusinessLogic;
        }
        public void AddNewProduct(Tbl_Product product)
        {
            _productRepository.Add(product);
        }
        public Tbl_Product CreateProductItem(object productObject)
        {
            JObject jObject = (JObject)productObject;
            Tbl_Product product = new Tbl_Product
            {
                Product_Id = Guid.NewGuid().ToString(),
                Product_Name = jObject["productName"].ToString(),
                Product_Favorite = 0,
                Product_Location = (int)jObject["productLocation"],
                Product_Price = (decimal)jObject["productPrice"],
                Product_Rating = 0,
                Product_Review = 0,
                Product_Stock = (int)jObject["productStock"],
                Product_Description = (string)jObject["productDescription"]
            };
            if (jObject["TblProductImage"] != null)
            {
                JObject[] productImage = (JObject[])jObject["TblProductImage"].ToObject(typeof(JObject[]));
                List<Tbl_Product_Image> list = new List<Tbl_Product_Image>();
                foreach (var item in productImage)
                {
                    list.Add(new Tbl_Product_Image
                    {
                        P_Image_Id = Guid.NewGuid().ToString(),
                        Tbl_Product = product,
                        Product_Image_Name = item["productImageName"].ToString(),
                        Product_Image_Url = item["productImageUrl"].ToString(),
                        Product_Image_Size = (int)item["productImageSize"]
                    });
                }
                product.Tbl_Product_Image = list;
            }
            if (jObject["TblProductCategory"] != null)
            {
                JObject[] categories = (JObject[])jObject["TblProductCategory"].ToObject(typeof(JObject[]));
                List<Tbl_Product_Category> list = new List<Tbl_Product_Category>();
                foreach (var item in categories)
                {
                    list.Add(new Tbl_Product_Category
                    {
                        Tbl_Product = product,
                        P_Category_Id = Guid.NewGuid().ToString(),
                        Tbl_Category= _categoryBusinessLogic.GetTblCategoryByName(item["categoryName"].ToString())
                    });
                }
                product.Tbl_Product_Category = list;
            }
            if (jObject["TblProductSpecs"] != null)
            {
                JObject[] specs = (JObject[])jObject["TblProductSpecs"].ToObject(typeof(JObject[]));
                List<Tbl_Product_Specs> list = new List<Tbl_Product_Specs>();
                foreach (var item in specs)
                {
                    list.Add(new Tbl_Product_Specs
                    {
                        Tbl_Product= product,
                        P_Spec_Id = Guid.NewGuid().ToString(),
                        Product_Spec_Title = item["productSpecTitle"].ToString(),
                        Product_Spec_Value = item["productSpecValue"].ToString()
                    });
                }
                product.Tbl_Product_Specs = list;
            }
            if (jObject["TblProductVariations"] != null)
            {
                JObject[] variations = (JObject[])jObject["TblProductVariations"].ToObject(typeof(JObject[]));
                List<Tbl_Product_Variations> list = new List<Tbl_Product_Variations>();
                foreach (var item in variations)
                {
                    list.Add(new Tbl_Product_Variations
                    {
                        Tbl_Product= product,
                        Product_Variation = item["productVariation"].ToString(),
                        P_Variation_Id = Guid.NewGuid().ToString()
                    });
                }
                product.Tbl_Product_Variations = list;
            }
            return product;
        }
        public IEnumerable<Tbl_Product> GetAllListProduct()
        {
            return _productRepository.GetAll();
        }
        public Tbl_Product GetProductById(string ProductId)
        {
            return _productRepository.GetSingle(x => x.Product_Id == ProductId);
        }
        public void AddReview(string productId)
        {
            _productRepository.AddReview(productId);
        }

        public int SaveProduct()
        {
            return _productRepository.Commit();
        }
    }
}
