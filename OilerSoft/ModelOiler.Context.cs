﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OilerSoft
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OilerProjectEntities : DbContext
    {
        public OilerProjectEntities()
            : base("name=OilerProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarSet> CarSet { get; set; }
        public virtual DbSet<ClientSet> ClientSet { get; set; }
        public virtual DbSet<OrderSpareSet> OrderSpareSet { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<SpareSet> SpareSet { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
