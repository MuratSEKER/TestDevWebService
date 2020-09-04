using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDevWebApp.Models
{
    public class UserDto
    {
        public string Username { get; set; }
        public string RoleDescription { get; set; }
        public List<SelectListItem> UserList { get; set; } = new List<SelectListItem>();
    }
}
