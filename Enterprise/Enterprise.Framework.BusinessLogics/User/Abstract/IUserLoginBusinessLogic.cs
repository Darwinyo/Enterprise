using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using System.Collections.Generic;

namespace Enterprise.Framework.BusinessLogics.User.Abstract
{
    public interface IUserLoginBusinessLogic
    {
        bool IsUserLoginExists(IEnumerable<string> sameRecord);
        IEnumerable<string> GetSameRecord(TblUserLogin userLogin);
        void RegisterUser(TblUserLogin userLogin);
        bool Login(TblUserLogin userLogin);
        TblUserLogin CreateUserLogin(object value);
        void SaveUser();
    }
}
