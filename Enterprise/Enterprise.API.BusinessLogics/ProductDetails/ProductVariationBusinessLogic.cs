using System;
using System.Collections.Generic;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using System.Linq;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.ProductDetails
{
    public class ProductVariationBusinessLogic:IProductVariationBusinessLogic
    {
        public void InsertNewVariations(IEnumerable<TblProductVariations> listVariation, ITblProductVariationsRepository productVariationsRepository)
        {
            if (listVariation != null)
                foreach (var variation in listVariation)
                {
                    productVariationsRepository.Add(variation);
                }
        }
        public IEnumerable<TblProductVariations> GetProductVariationByProductId(string productId, ITblProductVariationsRepository productVariationsRepository)
        {
            return productVariationsRepository.FindBy(x => x.ProductId == productId).AsEnumerable();
        }
        public int SaveVariation(ITblProductVariationsRepository productVariationsRepository)
        {
            return productVariationsRepository.Commit();
        }
    }
}
