using System;
using System.Collections.Generic;
using System.Text;
using MM = Enterprise.DataLayers.EnterpriseDB_MongoModel;
namespace Enterprise.API.BusinessLogics.Mongo
{
    public class TblProductCommentsBusinessLogic
    {
        public static List<MM.TblProductComments> GetAllCommentListByProductIdAsync(string productId, MM.MongoContext context)
        {
            return MM.TblProductComments.GetAllCommentListByProductIdAsync(productId, context);
        }
    }
}
