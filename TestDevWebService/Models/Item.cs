using System;
using System.Collections.Generic;

namespace TestDevWebService.Models
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Name { get; set; }
        public string Game { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
