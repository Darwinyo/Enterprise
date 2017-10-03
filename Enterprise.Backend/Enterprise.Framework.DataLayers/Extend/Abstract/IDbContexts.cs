using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.DataLayers.Extend.Abstract
{
    public interface IHelperContext : IBaseDbContext
    {
        int sp_Generate_Periode(string periodeId, string periodeDescription, Nullable<System.DateTime> periodeStartDate, Nullable<System.DateTime> periodeEndDate);
    }
    public interface IUserContext : IBaseDbContext
    {

    }
    public interface IProductContext : IBaseDbContext
    {
        int sp_AddReview(string productId);
        int sp_Generate_HotProduct(string periodeId);
        int sp_Generate_ProductRecommend(string periodeId);
    }
    public interface ITransactionContext : IBaseDbContext
    {

    }
}
