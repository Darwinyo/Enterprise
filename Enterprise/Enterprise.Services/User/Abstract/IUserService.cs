
using Enterprise.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Services.User.Abstract
{
    public interface IUserService
    {
        //Task<StartRegistrationResponse> Registration(object userLoginObj);
        Task<UserRegistrationWorkflowResponse> Registration(object userLoginObj);
        bool IsEmailRegistered(string email);
        bool IsPhoneRegistered(string phone);
        bool IsUserLoginRegistered(string userLogin);
        Task<UserLoginResponse> LoginUser(string userLogin, string password);
    }
}
