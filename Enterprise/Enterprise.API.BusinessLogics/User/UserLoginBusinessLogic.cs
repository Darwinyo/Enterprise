using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using Enterprise.API.BusinessLogics.User.Abstract;
using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Enterprise.Repository.Abstract;

namespace Enterprise.API.BusinessLogics.User
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
                PhoneNumber = (int)jObject["phoneNumber"],
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

        public bool IsUserLoginExists(IEnumerable<string> sameRecord)
        {
            return sameRecord.Count() > 0 ? true : false;
        }

        public bool Login(TblUserLogin userLogin)
        {
            return _userLoginRepository.FindBy(x => x.Equals(userLogin)).Count() > 0 ? true : false;
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
