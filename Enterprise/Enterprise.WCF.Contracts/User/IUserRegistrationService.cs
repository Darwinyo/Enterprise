using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Enterprise.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Enterprise.WCF.Contracts.User
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserRegistrationService" in both code and config file together.
    [ServiceContract]
    public interface IUserRegistrationService
    {
        [OperationContract]
        bool IsUserLoginExists(IEnumerable<string> sameRecord, ITblUserLoginRepository userLoginRepository);

        [OperationContract]
        IEnumerable<string> GetSameRecord(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository);

        [OperationContract]
        void RegisterUser(TblUserLogin userLogin, ITblUserLoginRepository userLoginRepository);

        [OperationContract]
        TblUserLogin CreateUserLogin(object value, ITblUserLoginRepository userLoginRepository);
        
    }
}
