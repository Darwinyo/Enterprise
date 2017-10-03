using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using Enterprise.Core.BusinessLogics.User.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_UserModel;
using Enterprise.Core.Repository.Abstract;
using System.Threading.Tasks;
using Enterprise.API.Models.Responses;
using Enterprise.API.Helpers.Consts;

namespace Enterprise.Core.BusinessLogics.User
{
    public class UserLoginBusinessLogic : IUserLoginBusinessLogic
    {
        private readonly ITblUserLoginRepository _userLoginRepository;
        public UserLoginBusinessLogic(ITblUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }
        public TblUserLogin CreateUserLogin(object value)
        {
            JObject jObject = (JObject)value;
            return new TblUserLogin
            {
                Email = jObject["email"].ToString(),
                Password = jObject["password"].ToString(),
                PhoneNumber = jObject["phoneNumber"].ToString(),
                UserLogin = jObject["userLogin"].ToString()
            };
        }

        public IEnumerable<string> GetSameRecord(TblUserLogin userLogin)
        {
            List<string> lstError = new List<string>();
            if (_userLoginRepository.FindBy(x => x.Email == userLogin.Email).Count() > 0)
                lstError.Add("Email");
            if (_userLoginRepository.FindBy(x => x.PhoneNumber == userLogin.PhoneNumber).Count() > 0)
                lstError.Add("PhoneNumber");
            if (_userLoginRepository.FindBy(x => x.UserLogin == userLogin.UserLogin).Count() > 0)
                lstError.Add("UserLogin");
            return lstError.AsEnumerable();
        }

        public bool IsEmailRegistered(string email)
        {
            TblUserLogin User = _userLoginRepository.GetSingle(x => x.Email == email);
            if (User == null)
            {
                return false;
            }
            return true;
        }

        public bool IsPhoneRegistered(string phone)
        {
            TblUserLogin User = _userLoginRepository.GetSingle(x => x.PhoneNumber == phone);
            if (User == null)
            {
                return false;
            }
            return true;
        }

        public bool IsUserLoginExists(IEnumerable<string> sameRecord)
        {
            return sameRecord.Count() > 0 ? true : false;
        }

        public bool IsUserLoginRegistered(string userLogin)
        {
            TblUserLogin User = _userLoginRepository.GetSingle(x => x.UserLogin == userLogin);
            if (User == null)
            {
                return false;
            }
            return true;
        }

        public UserLoginResponse Login(string userLogin,out string encrypted)
        {
            UserLoginResponse userLoginResponse = new UserLoginResponse
            {
                UserKey = Guid.NewGuid().ToString(),
                UserLogin = userLogin
            };
            encrypted = _userLoginRepository.GetSingle(x => x.UserLogin == userLoginResponse.UserLogin).Password;
            return userLoginResponse;
        }

        public void RegisterUser(TblUserLogin userLogin)
        {
            _userLoginRepository.Add(userLogin);
        }

        public void SaveUser()
        {
            _userLoginRepository.Commit();
        }
    }
}
