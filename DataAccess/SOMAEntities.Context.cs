﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class somaEntities : DbContext
    {
        public somaEntities()
            : base("name=somaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<M_PartType> M_PartType { get; set; }
        public virtual DbSet<M_User> M_User { get; set; }
        public virtual DbSet<T_Part> T_Part { get; set; }
        public virtual DbSet<M_Model> M_Model { get; set; }
        public virtual DbSet<M_ModelManufacturer> M_ModelManufacturer { get; set; }
        public virtual DbSet<M_ProductCategory> M_ProductCategory { get; set; }
        public virtual DbSet<M_SubType> M_SubType { get; set; }
        public virtual DbSet<M_PartCondition> M_PartCondition { get; set; }
        public virtual DbSet<M_Status> M_Status { get; set; }
        public virtual DbSet<M_Type> M_Type { get; set; }
        public virtual DbSet<M_UserType> M_UserType { get; set; }
        public virtual DbSet<M_Vendor> M_Vendor { get; set; }
        public virtual DbSet<M_VendorType> M_VendorType { get; set; }
        public virtual DbSet<T_AlternatePart> T_AlternatePart { get; set; }
        public virtual DbSet<T_PartConditionPrice> T_PartConditionPrice { get; set; }
        public virtual DbSet<T_PartImage> T_PartImage { get; set; }
        public virtual DbSet<T_PartLink> T_PartLink { get; set; }
        public virtual DbSet<T_PartLogistics> T_PartLogistics { get; set; }
        public virtual DbSet<T_PartSuppier> T_PartSuppier { get; set; }
        public virtual DbSet<T_RelatedPart> T_RelatedPart { get; set; }
        public virtual DbSet<UserMenuTran> UserMenuTrans { get; set; }
        public virtual DbSet<v_PartsCompatibility> v_PartsCompatibility { get; set; }
    }
}
