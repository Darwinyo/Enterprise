using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_UserModel;
namespace Enterprise.Core.Repository.UserRepository
{
    public class TblUserLoginRepository : UserBaseRepository<TblUserLogin>, ITblUserLoginRepository
    {
        public TblUserLoginRepository(UserContext context) : base(context)
        {
        }
    }
}
