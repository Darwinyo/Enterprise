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
    
    public partial class TblCity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
    
        public virtual TblCountry TblCountry { get; set; }
    }
}
