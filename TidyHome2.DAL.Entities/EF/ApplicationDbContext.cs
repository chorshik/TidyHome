using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TidyHome2.DAL.Entities.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using TidyHome2.DAL.Entities.EntityConfig;

namespace TidyHome2.DAL.Entities.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));

            modelBuilder.Configurations.Add(new UsersConfig());
            modelBuilder.Configurations.Add(new RolesConfig());
        }


        public virtual DbSet<Roles> Roles { get; set; } 
        public virtual DbSet<Users> Users { get; set; }
       
    }
}
