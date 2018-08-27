using System;
using System.Collections.Generic;

namespace TidyHome2.DAL.Entities.Entities
{
    
    
    public partial class Roles
    {
        public Roles()
        {
            this.Users = new HashSet<Users>();
        }
    
        public long IdRole { get; set; }
        public string Role { get; set; }
    
        public virtual ICollection<Users> Users { get; set; }
    }
}
