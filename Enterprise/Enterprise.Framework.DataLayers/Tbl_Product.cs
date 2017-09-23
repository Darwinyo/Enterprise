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
    
    public partial class Tbl_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Product()
        {
            this.Tbl_Product_Category = new HashSet<Tbl_Product_Category>();
            this.Tbl_Product_Hot = new HashSet<Tbl_Product_Hot>();
            this.Tbl_Product_Image = new HashSet<Tbl_Product_Image>();
            this.Tbl_Product_Recommended = new HashSet<Tbl_Product_Recommended>();
            this.Tbl_Product_Specs = new HashSet<Tbl_Product_Specs>();
            this.Tbl_Product_Variations = new HashSet<Tbl_Product_Variations>();
        }
    
        public string Product_Id { get; set; }
        public int Product_Favorite { get; set; }
        public int Product_Location { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public decimal Product_Rating { get; set; }
        public int Product_Review { get; set; }
        public int Product_Stock { get; set; }
        public string Product_Description { get; set; }
        public string Product_Front_Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Product_Category> Tbl_Product_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Product_Hot> Tbl_Product_Hot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Product_Image> Tbl_Product_Image { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Product_Recommended> Tbl_Product_Recommended { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Product_Specs> Tbl_Product_Specs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Product_Variations> Tbl_Product_Variations { get; set; }
    }
}