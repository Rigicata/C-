﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiarioJulia
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
    
        public virtual DbSet<Registro> RegistroSet { get; set; }
        public virtual DbSet<Personagem> PersonagemSet { get; set; }
        public virtual DbSet<Registro_Personagem> Registro_PersonagemSet { get; set; }
        public virtual DbSet<Local> LocalSet { get; set; }
        public virtual DbSet<Melhoria> MelhoriaSet { get; set; }
    }
}
