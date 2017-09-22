using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.Framework.BusinessLogics.User.Abstract
{
    public interface IUserLoginBusinessLogic
    {
        bool IsUserLoginExists(IEnumerable<string> sameRecord);
        string[] GetSameRecord(Tbl_User_Login userLogin);
        void RegisterUser(Tbl_User_Login userLogin);
        bool Login(Tbl_User_Login userLogin);
        Tbl_User_Login CreateUserLogin(object value);
        void SaveUser();
    }
}
