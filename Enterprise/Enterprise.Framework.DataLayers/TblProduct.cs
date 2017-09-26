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
    
    public partial class TblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblProduct()
        {
            this.TblProductCategory = new HashSet<TblProductCategory>();
            this.TblProductHot = new HashSet<TblProductHot>();
            this.TblProductImage = new HashSet<TblProductImage>();
            this.TblProductRecommended = new HashSet<TblProductRecommended>();
            this.TblProductSpecs = new HashSet<TblProductSpecs>();
            this.TblProductVariations = new HashSet<TblProductVariations>();
        }
    
        public string ProductId { get; set; }
        public int ProductFavorite { get; set; }
        public int ProductLocation { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductRating { get; set; }
        public int ProductReview { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductFrontImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductCategory> TblProductCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductHot> TblProductHot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductImage> TblProductImage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductRecommended> TblProductRecommended { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductSpecs> TblProductSpecs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductVariations> TblProductVariations { get; set; }
    }
}
