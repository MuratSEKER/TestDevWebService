using System;
using System.Collections.Generic;

namespace TestDevWebService.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
