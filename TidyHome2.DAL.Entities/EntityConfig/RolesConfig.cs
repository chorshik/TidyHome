using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TidyHome2.DAL.Entities.Entities;

namespace TidyHome2.DAL.Entities.EntityConfig
{
    public class RolesConfig: EntityTypeConfiguration<Roles>
    {
        public RolesConfig()
        {
            HasKey(c => c.IdRole);

            Property(c => c.Role)
                .IsRequired()
                .HasMaxLength(150);

        }
    }
}
