using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_UserModel
{
    public partial class TblProfileImage
    {
        public string ProfileImageId { get; set; }
        public string UserDetailId { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ProfileImageName { get; set; }
        public int ProfileImageSize { get; set; }

        public TblUserDetails UserDetail { get; set; }
    }
}
