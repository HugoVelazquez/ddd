﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Example.DataPersistent.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Domain.Entity;

    public partial class FINANTIALModel : DbContext
    {
        public FINANTIALModel()
            : base("name=FINANTIALModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATESTATUSPAGO> CATESTATUSPAGO { get; set; }
        public virtual DbSet<CATFORMAPAGO> CATFORMAPAGO { get; set; }
        public virtual DbSet<CATTIPODOCUMENTO> CATTIPODOCUMENTO { get; set; }
    }
}
