using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.Repository.Abstract;
using Enterprise.API.BusinessLogics.Product.Abstract;

namespace Enterprise.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        public ProductService(IProductBusinessLogic productBusinessLogic)
        {
            _productBusinessLogic = productBusinessLogic;
        }
        public void AddNewProduct(TblProduct product)
        {
            _productBusinessLogic.AddNewProduct(product);
        }

        public void AddReview(string productId)
        {
            _productBusinessLogic.AddReview(productId);
        }

        public IEnumerable<TblProduct> GetAllListProduct()
        {
            return _productBusinessLogic.GetAllListProduct();
        }

        public TblProduct GetProductById(string ProductId)
        {
            return _productBusinessLogic.GetProductById(ProductId);
        }

        public int SaveProduct()
        {
            return _productBusinessLogic.SaveProduct();
        }
    }
}
