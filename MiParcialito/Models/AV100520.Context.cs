﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiParcialito.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AV100520Entities : DbContext
    {
        public AV100520Entities()
            : base("name=AV100520Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cursos> cursos { get; set; }
        public virtual DbSet<docentes> docentes { get; set; }
        public virtual DbSet<inscripciones> inscripciones { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}
