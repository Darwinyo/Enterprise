using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Framework.Repository.UserRepository
{
    public class TblUserLoginRepository : UserBaseRepository<Tbl_User_Login>, ITblUserLoginRepository
    {
        public TblUserLoginRepository(UserContext context) : base(context)
        {
        }
    }
}
