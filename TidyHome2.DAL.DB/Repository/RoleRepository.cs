using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyHome2.DAL.Entities.Entities;
using TidyHome2.DAL.DB.Interfaces;

namespace TidyHome2.DAL.DB.Repository
{
    public class RoleRepository : BaseRepository<Roles>
    {
        public RoleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            return Context.ToList();
        }


    }
}
