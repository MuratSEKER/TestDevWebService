using System;
using System.Collections.Generic;

namespace TestDevWebApp.Models
{
    public partial class Role
    {
        //public Role()
        //{
        //    User = new HashSet<User>();
        //}

        public int IdRole { get; set; }
        public string RoleDescription { get; set; }

        //public virtual ICollection<User> User { get; set; }
    }
}
