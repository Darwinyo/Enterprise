using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.DTOs.Product;

namespace Enterprise.Framework.Repository.Abstract
{
    #region product
    public interface ITblProductRepository : IEntityBaseRepository<TblProduct>
    {
        IEnumerable<ProductCardDTO> GetListProductCardByListString(List<string> listProductId);
        void AddReview(string productId);
    };
    public interface ITblProductHotRepository : IEntityBaseRepository<TblProductHot> { };
    public interface ITblCategoryRepository : IEntityBaseRepository<TblCategory> { };
    public interface ITblProductImageRepository : IEntityBaseRepository<TblProductImage> { };
    public interface ITblProductRecommendedRepository : IEntityBaseRepository<TblProductRecommended> { };
    public interface ITblProductSpecsRepository : IEntityBaseRepository<TblProductSpecs> { };
    public interface ITblProductVariationsRepository : IEntityBaseRepository<TblProductVariations> { };
    #endregion

    #region user
    public interface ITblUserLoginRepository : IEntityBaseRepository<TblUserLogin> { };
    public interface ITblUserDetailsRepository : IEntityBaseRepository<TblUserDetails> { };
    #endregion

    #region helper
    public interface ITblCityRepository : IEntityBaseRepository<TblCity> { };
    public interface ITblPeriodeRepository : IEntityBaseRepository<TblPeriode>
    {
        int CreatePeriode(TblPeriode tblPeriode);
    };
    #endregion

    #region mongo
    #endregion
}
