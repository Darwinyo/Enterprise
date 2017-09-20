using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Enterprise.API.BusinessLogics.User;
using Enterprise.Repository.Abstract;

namespace Enterprise.WCF.Contracts.User
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserRegistrationService" in both code and config file together.
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserLoginBusinessLogic _userLoginBusinessLogic;
        public UserRegistrationService()
        {
            _userLoginBusinessLogic = new UserLoginBusinessLogic();
        }

        public TblUserLogin CreateUserLogin(object value, ITblUserLoginRepository userLoginRepository)
        {
            return _userLoginBusinessLogic.CreateUserLogin(value, userLoginRepository);
        }

        public IEnumerable<string> GetSameRecord(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository)
        {
            return _userLoginBusinessLogic.GetSameRecord(userLogin, userLoginRepository);
        }

        public bool IsUserLoginExists(IEnumerable<string> sameRecord, ITblUserLoginRepository userLoginRepository)
        {
            return _userLoginBusinessLogic.IsUserLoginExists(sameRecord, userLoginRepository);
        }

        public void RegisterUser(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository)
        {
            _userLoginBusinessLogic.RegisterUser(userLogin, userLoginRepository);
            _userLoginBusinessLogic.SaveUser(userLoginRepository);
        }
    }
}
