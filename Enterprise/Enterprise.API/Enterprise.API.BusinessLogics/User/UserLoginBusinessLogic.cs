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
        public TblUserLogin CreateUserLogin(object value, ITblUserLoginRepository userLoginRepository)
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

        public IEnumerable<string> GetSameRecord(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository)
        {
            List<string> lstError = new List<string>();
            if (userLoginRepository.FindBy(x => x.Email == userLogin.Email).Count() > 0)
                lstError.Add("Email");
            if (userLoginRepository.FindBy(x => x.PhoneNumber == userLogin.PhoneNumber).Count() > 0)
                lstError.Add("PhoneNumber");
            if (userLoginRepository.FindBy(x => x.UserLogin == userLogin.UserLogin).Count() > 0)
                lstError.Add("UserLogin");
            return lstError.AsEnumerable();
        }

        public bool IsUserLoginExists(IEnumerable<string> sameRecord, ITblUserLoginRepository userLoginRepository)
        {
            return sameRecord.Count() > 0 ? true : false;
        }

        public bool Login(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository)
        {
            return userLoginRepository.FindBy(x => x.Equals(userLogin)).Count() > 0 ? true : false;
        }

        public void RegisterUser(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository)
        {
            userLoginRepository.Add(userLogin);
        }

        public void SaveUser(ITblUserLoginRepository userLoginRepository)
        {
            userLoginRepository.Commit();
        }
    }
}
