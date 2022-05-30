using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class Role
    {
        public Role()
        {
            SportCenterAdmins = new HashSet<SportCenterAdmin>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SportCenterAdmin> SportCenterAdmins { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
