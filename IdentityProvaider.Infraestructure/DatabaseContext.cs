﻿using IdentityProvaider.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityProvaider.Infraestructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<User>(o =>
            {
                o.HasKey(x => x.id_user).HasName("id_user");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.email, conf =>
            {
                conf.Property(x => x.value).HasColumnName("email");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.name, conf =>
            {
                conf.Property(x => x.value).HasColumnName("name");
            });
           
            modelBuilder.Entity<User>().OwnsOne(o => o.lastName, conf =>
            {
                conf.Property(x => x.value).HasColumnName("last_name");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.typeDocument, conf =>
            {
                conf.Property(x => x.value).HasColumnName("type_document");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.identification, conf =>
            {
                conf.Property(x => x.value).HasColumnName("document_number");
            });           

            modelBuilder.Entity<User>().OwnsOne(o => o.creationDate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("creation_date");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.direction, conf =>
            {
                conf.Property(x => x.value).HasColumnName("direccion");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}