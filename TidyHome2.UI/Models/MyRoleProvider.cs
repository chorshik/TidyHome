using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TidyHome2.BLL.Service;

namespace TidyHome2.UI.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private readonly RoleService _roleService;
        public MyRoleProvider()
        {
            _roleService = new RoleService();
        }
        public override string[] GetAllRoles()
        {
            return _roleService.GetAllRolesToString();
        }

        public override string[] GetRolesForUser(string username)
        {
            return _roleService.GetRolesForUserToString(username);
        }

        #region Not Used
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}