﻿using System;
using System.Collections.Generic;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using System.Linq;
using Enterprise.Core.BusinessLogics.ProductDetails.Abstract;
using Enterprise.Core.Repository.Abstract;

namespace Enterprise.Core.BusinessLogics.ProductDetails
{
    public class ProductVariationBusinessLogic:IProductVariationBusinessLogic
    {
        private readonly ITblProductVariationsRepository _productVariationsRepository;
        public ProductVariationBusinessLogic(ITblProductVariationsRepository productVariationsRepository)
        {
            _productVariationsRepository = productVariationsRepository;
        }
        public void InsertNewVariations(IEnumerable<TblProductVariations> listVariation)
        {
            if (listVariation != null)
                foreach (var variation in listVariation)
                {
                    _productVariationsRepository.Add(variation);
                }
        }
        public IEnumerable<TblProductVariations> GetProductVariationByProductId(string productId)
        {
            return _productVariationsRepository.FindBy(x => x.ProductId == productId).AsEnumerable();
        }
        public int SaveVariation()
        {
            return _productVariationsRepository.Commit();
        }
    }
}
