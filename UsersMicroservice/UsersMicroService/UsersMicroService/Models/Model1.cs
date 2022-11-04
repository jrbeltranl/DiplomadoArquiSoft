using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace UsersMicroService.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelUsersDatabase")
        {
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolUsuario> RolUsuario { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>()
                .HasMany(e => e.RolUsuario)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.NivelEducativo)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .HasMany(e => e.RolUsuario)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.Usuario)
                .WillCascadeOnDelete(false);


        }
    }
}
