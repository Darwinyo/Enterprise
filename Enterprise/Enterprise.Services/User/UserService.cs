using System;
using System.Collections.Generic;
using System.Text;
using Enterprise.Services.User.Abstract;
using Enterprise.Repository.Abstract;
using System.Threading.Tasks;
using System.Net.Http;
using Enterprise.API.Helpers.Consts;
using Newtonsoft.Json;
using Enterprise.Workflows.Invoker.User.Abstraction;
using Enterprise.Workflows.Invoker.UserRegistrationWorkflowService;

namespace Enterprise.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserWorkflowInvoker _userWorkflowInvoker;
        public UserService(IUserWorkflowInvoker userWorkflowInvoker)
        {
            _userWorkflowInvoker = userWorkflowInvoker;
        }
        public async Task<StartRegistrationResponse> Registration(object userLoginObj)
        {
            return await _userWorkflowInvoker.UserLoginRegistration(userLoginObj);
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri(WorkflowServiceClient.BaseUrl);
            //    string content= JsonConvert.SerializeObject(userLoginObj) + JsonConvert.SerializeObject(_userWorkflowInvoker);
            //    var contentData = new StringContent(content, Encoding.UTF8, MediaTypes.Application_Json);
            //    HttpResponseMessage httpResponseMessage= httpClient.PostAsync(WorkflowServiceClient.UserRegistration, contentData).Result;
            //    return JsonConvert.DeserializeObject<StartRegistrationResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
            //}
        }
    }
}
