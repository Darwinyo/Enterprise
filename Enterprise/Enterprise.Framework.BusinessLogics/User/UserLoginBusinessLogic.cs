using Enterprise.Framework.BusinessLogics.User.Abstract;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise.Framework.BusinessLogics.User
{
    public class UserLoginBusinessLogic : IUserLoginBusinessLogic
    {
        private readonly ITblUserLoginRepository _userLoginRepository;
        public UserLoginBusinessLogic(ITblUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }
        public Tbl_User_Login CreateUserLogin(object value)
        {
            JObject jObject = (JObject)value;
            return new Tbl_User_Login
            {
                Email = jObject["email"].ToString(),
                Password = jObject["password"].ToString(),
                Phone_Number = (int)jObject["phoneNumber"],
                User_Login = jObject["userLogin"].ToString()
            };
        }

        public string[] GetSameRecord(Tbl_User_Login userLogin)
        {
            List<string> lstError = new List<string>();
            if (_userLoginRepository.FindBy(x => x.Email == userLogin.Email).Count() > 0)
                lstError.Add("Email");
            if (_userLoginRepository.FindBy(x => x.Phone_Number == userLogin.Phone_Number).Count() > 0)
                lstError.Add("PhoneNumber");
            if (_userLoginRepository.FindBy(x => x.User_Login == userLogin.User_Login).Count() > 0)
                lstError.Add("UserLogin");
            return lstError.ToArray();
        }

        public bool IsUserLoginExists(IEnumerable<string> sameRecord)
        {
            return sameRecord.Count() > 0 ? true : false;
        }

        public bool Login(Tbl_User_Login userLogin)
        {
            return _userLoginRepository.FindBy(x => x.Equals(userLogin)).Count() > 0 ? true : false;
        }

        public void RegisterUser(Tbl_User_Login userLogin)
        {
            _userLoginRepository.Add(userLogin);
        }

        public void SaveUser()
        {
            _userLoginRepository.Commit();
        }
    }
}
