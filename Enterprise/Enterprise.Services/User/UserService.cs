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
using Enterprise.API.BusinessLogics.User.Abstract;
using Enterprise.Services.Decryption.Abstract;
using Newtonsoft.Json.Linq;

namespace Enterprise.Services.User
{
    public class UserService : Bypasser<UserRegistrationWorkflowResponse,object>, IUserService
    {
        private readonly IUserLoginBusinessLogic _userLoginBusinessLogic;
        private readonly IDecryptionService _decryptionService;

        public UserService(IUserLoginBusinessLogic userLoginBusinessLogic, IDecryptionService decryptionService)
        {
            _userLoginBusinessLogic = userLoginBusinessLogic;
            _decryptionService = decryptionService;
        }
        public async Task<UserRegistrationWorkflowResponse> Registration(object userLoginObj)
        {
            return await PostAction(WorkflowServiceClient.UserRegistration, userLoginObj);
        }
        public bool IsEmailRegistered(string email)
        {
            return _userLoginBusinessLogic.IsEmailRegistered(email);
        }
        public bool IsPhoneRegistered(string phone)
        {
            return _userLoginBusinessLogic.IsPhoneRegistered(phone);
        }
        public bool IsUserLoginRegistered(string userLogin)
        {
            return _userLoginBusinessLogic.IsUserLoginRegistered(userLogin);
        }
        public async Task<UserLoginResponse> LoginUser(string userLogin, string password)
        {
            string encrypted;
            UserLoginResponse userLoginResponse= _userLoginBusinessLogic.Login(userLogin,out encrypted);
            userLoginResponse.IsLogged = await _decryptionService.DecryptText(encrypted) == password;
            return userLoginResponse;
        }
    }
}
