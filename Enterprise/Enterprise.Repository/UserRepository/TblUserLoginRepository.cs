using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Repository.Abstract;
using Enterprise.DataLayers.EnterpriseDB_UserModel;
namespace Enterprise.Repository.UserRepository
{
    public class TblUserLoginRepository : UserBaseRepository<TblUserLogin>, ITblUserLoginRepository
    {
        public TblUserLoginRepository(UserContext context) : base(context)
        {
        }
    }
}
