using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;

namespace Enterprise.DataLayers.EnterpriseDB_MongoModel
{
    public partial class TblProductComments
    {
        public static List<TblProductComments> GetAllCommentListByProductIdAsync(string productId,MongoContext context)
        {
            IMongoQuery filter = Query<TblProductComments>.EQ(x => x.ProductId,productId);
            return context.TblProductComments.Find(filter).ToList();
        }
    }
}
