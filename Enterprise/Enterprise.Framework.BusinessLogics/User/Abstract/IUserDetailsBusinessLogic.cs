using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.BusinessLogics.User.Abstract
{
    public interface IUserDetailsBusinessLogic
    {
        void InitInsertUserDetail(string guidString);
        void SaveUserDetails();
    }
}
