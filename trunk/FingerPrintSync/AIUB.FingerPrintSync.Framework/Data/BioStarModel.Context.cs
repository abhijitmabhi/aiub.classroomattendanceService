﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIUB.FingerPrintSync.Framework.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BioStarEntities : DbContext
    {
        public BioStarEntities()
            : base("name=BioStarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_EVENT_LOG> TB_EVENT_LOG { get; set; }
        public virtual DbSet<TB_USER> TB_USER { get; set; }
        public virtual DbSet<TB_READER> TB_READER { get; set; }
    }
}
