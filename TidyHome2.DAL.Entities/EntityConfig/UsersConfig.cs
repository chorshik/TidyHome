using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TidyHome2.DAL.Entities.Entities;


namespace TidyHome2.DAL.Entities.EntityConfig
{
    public class UsersConfig : EntityTypeConfiguration<Users>
    {
        public UsersConfig()
        {
            HasKey(c => c.IdUsers);

            Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Patronymic)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(12);

            Property(c => c.Email)
                .IsRequired();

        }
    }
}
