using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_UserModel
{
    public partial class TblUserCard
    {
        public string UserCardId { get; set; }
        public string CardType { get; set; }
        public string CardProvider { get; set; }
        public int CardNumber { get; set; }
        public string CardOwner { get; set; }
        public string UserDetailsId { get; set; }

        public TblUserDetails UserDetails { get; set; }
    }
}
