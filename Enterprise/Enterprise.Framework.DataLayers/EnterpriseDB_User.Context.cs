﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblPickUpLocation> TblPickUpLocation { get; set; }
        public virtual DbSet<TblProfileImage> TblProfileImage { get; set; }
        public virtual DbSet<TblUserCard> TblUserCard { get; set; }
        public virtual DbSet<TblUserDetails> TblUserDetails { get; set; }
        public virtual DbSet<TblUserLogin> TblUserLogin { get; set; }
    }
}
