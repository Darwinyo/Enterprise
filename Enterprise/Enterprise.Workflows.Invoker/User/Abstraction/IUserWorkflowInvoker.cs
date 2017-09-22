
using Enterprise.Framework.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflows.Invoker.User.Abstraction
{
    public interface IUserWorkflowInvoker
    {
        void UserLoginRegistration(Tbl_User_Login userLogin);
    }
}
