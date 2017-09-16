using System;
using System.Collections.Generic;

namespace Enterprise.DataLayers.EnterpriseDB_UserModel
{
    public partial class TblPickUpLocation
    {
        public string PickUpLocationId { get; set; }
        public string UserDetailId { get; set; }
        public string PickUpLocation1 { get; set; }
        public string PickUpLocation2 { get; set; }
        public string PickUpLocation3 { get; set; }

        public TblUserDetails UserDetail { get; set; }
    }
}
