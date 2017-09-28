using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Enterprise.DataLayers.DTOs.Product;

namespace Enterprise.Repository.Abstract
{
    #region product
    public interface ITblProductRepository : IEntityBaseRepository<TblProduct>
    {
        ProductDetailsDTO GetProductDetails(string productId);
        IEnumerable<TblProduct> GetListProductByListString(List<string> listProductId);
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
    #endregion

    #region helper
    public interface ITblCityRepository : IEntityBaseRepository<TblCity> { };
    public interface ITblPeriodeRepository : IEntityBaseRepository<TblPeriode>
    {
        int CreatePeriode(TblPeriode tblPeriode, HelperContext context);
    };
    #endregion

    #region mongo
    public interface ITblProductCommentsRepository : IMongoEntityBaseRepository<TblProductComments> { };
    public interface ITblChatRepository : IMongoEntityBaseRepository<TblChat> { };
    #endregion
}
