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
    
    public partial class TransactionContext : DbContext
    {
        public TransactionContext()
            : base("name=TransactionContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Balance> Tbl_Balance { get; set; }
        public virtual DbSet<Tbl_Product_Transaction> Tbl_Product_Transaction { get; set; }
        public virtual DbSet<Tbl_Transaction> Tbl_Transaction { get; set; }
    }
}
