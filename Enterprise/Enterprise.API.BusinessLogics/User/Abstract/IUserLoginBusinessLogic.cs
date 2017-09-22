using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.API.BusinessLogics.User.Abstract
{
    public interface IUserLoginBusinessLogic
    {
        bool IsUserLoginExists(IEnumerable<string> sameRecord);
        IEnumerable<string> GetSameRecord(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository);
        void RegisterUser(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository);
        bool Login(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository);
        TblUserLogin CreateUserLogin(object value);
        void SaveUser(ITblUserLoginRepository userLoginRepository);
    }
}
