using System.Collections.Generic;
using System.Linq;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.ProductDetails
{
    public class ProductImageBusinessLogic:IProductImageBusinessLogic
    {
        public IEnumerable<TblProductImage> GetProductImageListByProductId(string productId, ITblProductImageRepository productImageRepository)
        {
            if (productId != string.Empty || productId != null)
                return productImageRepository.FindBy(x => x.ProductId == productId).AsEnumerable();
            return null;
        }
    }
}
