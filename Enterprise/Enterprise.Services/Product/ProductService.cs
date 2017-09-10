using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.Repository.Abstract;

namespace Enterprise.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ProductBusinessLogic _productBusinessLogic;
        private readonly ITblProductRepository _tblProductRepository;
        private readonly ITblCategoryRepository _tblCategoryRepository;
        public ProductService(ITblProductRepository tblProductRepository,ITblCategoryRepository tblCategoryRepository)
        {
            _tblProductRepository = tblProductRepository;
            _tblCategoryRepository = tblCategoryRepository;
            _productBusinessLogic = new ProductBusinessLogic();
        }
        public void AddNewProduct(object obj)
        {
            _productBusinessLogic.AddNewProduct(obj, _tblProductRepository, _tblCategoryRepository);
        }

        public void AddReview(string productId)
        {
            _productBusinessLogic.AddReview(productId, _tblProductRepository);
        }

        public IEnumerable<TblProduct> GetAllListProduct()
        {
            return _productBusinessLogic.GetAllListProduct(_tblProductRepository);
        }

        public TblProduct GetProductById(string ProductId)
        {
            return _productBusinessLogic.GetProductById(ProductId, _tblProductRepository);
        }

        public int SaveProduct()
        {
            return _productBusinessLogic.SaveProduct(_tblProductRepository);
        }
    }
}
