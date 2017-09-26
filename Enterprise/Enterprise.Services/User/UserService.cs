using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Services.User.Abstract;
using System.Threading.Tasks;
using System.Net.Http;
using Enterprise.API.Helpers.Consts;
using Newtonsoft.Json;
using Enterprise.API.Helpers.ProxyAPI;
using Enterprise.API.Models.Responses;

namespace Enterprise.Services.User
{
    public class UserService : Bypasser<UserRegistrationWorkflowResponse,object>, IUserService
    {
        public async Task<UserRegistrationWorkflowResponse> Registration(object userLoginObj)
        {
            return await PostAction(WorkflowServiceClient.UserRegistration, userLoginObj);
        }
    }
}
