﻿using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_UserModel
{
    public partial class TblUserLogin
    {
        public string UserLoginId { get; set; }
        public string UserLogin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string UserDetailId { get; set; }

        public TblUserDetails UserDetail { get; set; }
    }
}
