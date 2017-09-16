using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_UserModel
{
    public partial class TblUserLogin
    {
        public string UserLoginId { get; set; }
        public string UserLogin { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public string UserDetailId { get; set; }

        public TblUserDetails UserDetail { get; set; }
    }
}
