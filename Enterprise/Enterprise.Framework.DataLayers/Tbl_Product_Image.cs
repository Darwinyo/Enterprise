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
    
    public partial class Tbl_Product_Image
    {
        public string P_Image_Id { get; set; }
        public string Product_Id { get; set; }
        public string Product_Image_Url { get; set; }
        public string Product_Image_Name { get; set; }
        public int Product_Image_Size { get; set; }
    
        public virtual Tbl_Product Tbl_Product { get; set; }
    }
}