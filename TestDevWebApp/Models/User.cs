using System;
using System.Collections.Generic;

namespace TestDevWebApp.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? IdRole { get; set; }

        public virtual Role Role { get; set; }
    }
}
