﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jonghor.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JongHorDBEntities1 : DbContext
    {
        public JongHorDBEntities1()
            : base("name=JongHorDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dorm> Dorm { get; set; }
        public virtual DbSet<Dorm_Label> Dorm_Label { get; set; }
        public virtual DbSet<Dorm_Picture> Dorm_Picture { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Room_Reserved> Room_Reserved { get; set; }
        public virtual DbSet<Room_Type> Room_Type { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<Dorm_Option> Dorm_Option { get; set; }
        public virtual DbSet<Dorm_Rate> Dorm_Rate { get; set; }
        public virtual DbSet<Room_Option> Room_Option { get; set; }
    }
}
