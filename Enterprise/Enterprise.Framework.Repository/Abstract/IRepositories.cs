using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Framework.Repository.Abstract
{
    #region product
    public interface ITblProductRepository : IEntityBaseRepository<Tbl_Product>
    {
        IEnumerable<Tbl_Product> GetListProductByListString(List<string> listProductId);
        void AddReview(string productId);
    };
    public interface ITblProductHotRepository : IEntityBaseRepository<Tbl_Product_Hot> { };
    public interface ITblCategoryRepository : IEntityBaseRepository<Tbl_Category> { };
    public interface ITblProductImageRepository : IEntityBaseRepository<Tbl_Product_Image> { };
    public interface ITblProductRecommendedRepository : IEntityBaseRepository<Tbl_Product_Recommended> { };
    public interface ITblProductSpecsRepository : IEntityBaseRepository<Tbl_Product_Specs> { };
    public interface ITblProductVariationsRepository : IEntityBaseRepository<Tbl_Product_Variations> { };
    #endregion

    #region user
    public interface ITblUserLoginRepository : IEntityBaseRepository<Tbl_User_Login> { };
    #endregion

    #region helper
    public interface ITblCityRepository : IEntityBaseRepository<Tbl_City> { };
    public interface ITblPeriodeRepository : IEntityBaseRepository<Tbl_Periode>
    {
        int CreatePeriode(Tbl_Periode tblPeriode, HelperContext context);
    };
    #endregion

    #region mongo
    #endregion
}
