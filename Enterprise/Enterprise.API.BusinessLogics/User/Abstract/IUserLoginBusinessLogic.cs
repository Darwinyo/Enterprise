using Enterprise.API.Models.Responses;
using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Enterprise.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.API.BusinessLogics.User.Abstract
{
    public interface IUserLoginBusinessLogic
    {
        bool IsUserLoginExists(IEnumerable<string> sameRecord);
        IEnumerable<string> GetSameRecord(TblUserLogin userLogin);
        void RegisterUser(TblUserLogin userLogin);
        UserLoginResponse Login(string userLogin, out string encrypted);
        bool IsEmailRegistered(string email);
        bool IsPhoneRegistered(string phone);
        bool IsUserLoginRegistered(string userLogin);
        TblUserLogin CreateUserLogin(object value);
        void SaveUser();
    }
}
