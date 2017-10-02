using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.Repository.UserRepository
{
    public class TblUserDetailsRepository : UserBaseRepository<TblUserDetails>, ITblUserDetailsRepository
    {
        public TblUserDetailsRepository(UserContext context) : base(context)
        {
        }
    }
}
