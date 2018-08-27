using System;
using System.Collections.Generic;

namespace TidyHome2.DAL.Entities.Entities
{
    
    
    public partial class Users
    {
        public Users()
        {
            this.Roles = new HashSet<Roles>();           
        }
    
        public long IdUsers { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public string Address { get; set; }
        
        public string Phone { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<long> IdType { get; set; }
    
        
        public virtual ICollection<Roles> Roles { get; set; }
        
    }
}
