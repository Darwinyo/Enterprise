using Enterprise.Repository.Abstract;
using Enterprise.Workflows.Invoker.User.Abstraction;
using Enterprise.Workflows.Invoker.UserRegistrationWorkflowService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflows.Invoker.User
{
    public class UserWorkflowInvoker:IUserWorkflowInvoker
    {
        private readonly ITblUserLoginRepository _userLoginRepository;
        public UserWorkflowInvoker(ITblUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }
        public async Task<StartRegistrationResponse> UserLoginRegistration(object userLogin)
        {
            ServiceClient serviceClient = new ServiceClient();
            StartRegistrationRequest startRegistrationRequest = new StartRegistrationRequest(userLogin, _userLoginRepository);
            return await serviceClient.StartRegistrationAsync(startRegistrationRequest);
        }
    }
}
