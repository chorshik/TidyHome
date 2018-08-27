using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyHome2.DAL.Entities.Entities;
using TidyHome2.DAL.DB.Repository;

namespace TidyHome2.BLL.Service
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;
        private readonly UserRepository _userRepository;
        public RoleService()
        {
            var databaseFactory = new DatabaseFactory();
            _roleRepository = new RoleRepository(databaseFactory);
            _userRepository = new UserRepository(databaseFactory);
        }
        public IEnumerable<Roles> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
        public IEnumerable<Roles> GetRolesUserById(long id)
        {
            return _userRepository.GetRolesUserById(id);
        }
        public string[] GetAllRolesToString()
        {
            var roles = _roleRepository.GetAllRoles().ToArray();
            String[] r = new String[roles.Length];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = roles[i].Role;
            }
            return r;
        }

        public string[] GetRolesForUserToString(string username)
        {
            var roles = _userRepository.GetRolesUserById(username).ToArray();
            String[] r = new String[roles.Length];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = roles[i].Role;
            }
            return r;
        }
    }
}
