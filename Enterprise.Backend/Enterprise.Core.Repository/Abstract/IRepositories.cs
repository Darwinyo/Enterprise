using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.Core.DataLayers.EnterpriseDB_UserModel;
using Enterprise.Core.DataLayers.DTOs.Product;

namespace Enterprise.Core.Repository.Abstract
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
        int CreatePeriode(TblPeriode tblPeriode);
    };
    #endregion

    #region mongo
    public interface ITblProductCommentsRepository : IMongoEntityBaseRepository<TblProductComments> { };
    public interface ITblChatRepository : IMongoEntityBaseRepository<TblChat> { };
    #endregion
}
