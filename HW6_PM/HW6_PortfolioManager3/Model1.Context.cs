﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HW6_PortfolioManager3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Instrument> Instruments { get; set; }
        public virtual DbSet<Underlying> Underlyings { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<InstType> InstTypes { get; set; }
        public virtual DbSet<Trade> Trades { get; set; }
        public virtual DbSet<InterestRate> InterestRates { get; set; }
    }
}