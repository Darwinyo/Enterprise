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
    
    public partial class TblProductVariations
    {
        public string PVariationId { get; set; }
        public string ProductId { get; set; }
        public string ProductVariation { get; set; }
    
        public virtual TblProduct TblProduct { get; set; }
    }
}
