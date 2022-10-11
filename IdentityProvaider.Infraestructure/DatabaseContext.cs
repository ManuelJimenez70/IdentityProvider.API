using IdentityProvaider.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityProvaider.Infraestructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Password> SecurityPasswords { get; set; }

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

            modelBuilder.Entity<Role>(o =>
            {
                o.HasKey(x => x.id_rol).HasName("id_rol");
            });

            modelBuilder.Entity<Role>().OwnsOne(o => o.name, conf =>
            {
                conf.Property(x => x.value).HasColumnName("rol_name");
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Password>(o =>
            {
                o.HasKey(x => x.hash).HasName("hash");
            });
            modelBuilder.Entity<Password>().OwnsOne(o => o.password, conf =>
            {
                conf.Property(x => x.value).HasColumnName("password");
            });
        }

    }
}