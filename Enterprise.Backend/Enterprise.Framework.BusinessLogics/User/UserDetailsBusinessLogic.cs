using Enterprise.Framework.BusinessLogics.User.Abstract;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.BusinessLogics.User
{
    public class UserDetailsBusinessLogic : IUserDetailsBusinessLogic
    {
        private readonly ITblUserDetailsRepository _userDetailsRepository;
        public UserDetailsBusinessLogic(ITblUserDetailsRepository userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }
        public void InitInsertUserDetail(string guidString)
        {
            TblUserDetails userDetails = new TblUserDetails
            {
                UserDetailsId = guidString
            };
            this._userDetailsRepository.Add(userDetails);
        }

        public void SaveUserDetails()
        {
            this._userDetailsRepository.Commit();
        }
    }
}
