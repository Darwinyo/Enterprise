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
    
    public partial class Tbl_User_Login
    {
        public string User_Login_Id { get; set; }
        public string User_Login { get; set; }
        public string Email { get; set; }
        public int Phone_Number { get; set; }
        public string Password { get; set; }
        public string User_Detail_Id { get; set; }
    
        public virtual Tbl_User_Details Tbl_User_Details { get; set; }
    }
}