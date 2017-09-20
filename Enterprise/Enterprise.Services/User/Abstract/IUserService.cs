using Enterprise.Workflows.Invoker.UserRegistrationWorkflowService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Services.User.Abstract
{
    public interface IUserService
    {
        Task<StartRegistrationResponse> Registration(object userLoginObj);
    }
}
