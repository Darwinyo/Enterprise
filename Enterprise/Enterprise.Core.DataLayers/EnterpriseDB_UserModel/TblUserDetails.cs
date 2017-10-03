using System;
using System.Collections.Generic;

namespace Enterprise.Core.DataLayers.EnterpriseDB_UserModel
{
    public partial class TblUserDetails
    {
        public TblUserDetails()
        {
            TblPickUpLocation = new HashSet<TblPickUpLocation>();
            TblProfileImage = new HashSet<TblProfileImage>();
            TblUserCard = new HashSet<TblUserCard>();
            TblUserLogin = new HashSet<TblUserLogin>();
        }

        public string UserDetailsId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailMain { get; set; }
        public string EmailSecondary { get; set; }
        public int? PhoneMain { get; set; }
        public int? PhoneSecondary { get; set; }
        public string AddressMain { get; set; }
        public string AddressSecondary { get; set; }
        public string AddressThird { get; set; }

        public ICollection<TblPickUpLocation> TblPickUpLocation { get; set; }
        public ICollection<TblProfileImage> TblProfileImage { get; set; }
        public ICollection<TblUserCard> TblUserCard { get; set; }
        public ICollection<TblUserLogin> TblUserLogin { get; set; }
    }
}
