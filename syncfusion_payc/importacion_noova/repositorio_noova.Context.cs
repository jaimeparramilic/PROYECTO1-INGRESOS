﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace importacion_noova
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class repositorio_noovaEntities : DbContext
    {
        public repositorio_noovaEntities()
            : base("name=repositorio_noovaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aceptacion_cliente> aceptacion_cliente { get; set; }
        public virtual DbSet<documentos_facturas> documentos_facturas { get; set; }
        public virtual DbSet<resoluciones_numeracion_facturas> resoluciones_numeracion_facturas { get; set; }
        public virtual DbSet<aceptacion_dian> aceptacion_dian { get; set; }
        public virtual DbSet<pruebas> pruebas { get; set; }
    }
}