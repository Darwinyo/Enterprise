//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Enterprise.Framework.DataLayers
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblProfileImage
    {
        public string ProfileImageId { get; set; }
        public string UserDetailId { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ProfileImageName { get; set; }
        public int ProfileImageSize { get; set; }
    
        public virtual TblUserDetails TblUserDetails { get; set; }
    }
}
