using Enterprise.Workflows.Invoker.UserRegistrationWorkflowService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflows.Invoker.User.Abstraction
{
    public interface IUserWorkflowInvoker
    {
        Task<StartRegistrationResponse> UserLoginRegistration(object userLogin);
    }
}
