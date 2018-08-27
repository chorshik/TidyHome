using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TidyHome2.DAL.Entities.Entities;

namespace TidyHome2.UI.Models
{
    public class RoleSelect
    {
        public long IdRole { get; set; }
        public string Role { get; set; }
        public bool Exist { get; set; }

        public static explicit operator RoleSelect(Roles model)
        {
            return new RoleSelect() { IdRole = model.IdRole, Role = model.Role };
        }
    }
}