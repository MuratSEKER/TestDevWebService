using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDevWebApp.Models
{
    public class UserDataDto
    {
        public int idUser { get; set; }
        public string userName { get; set; }
        public List<Items> items { get; set; }
    }
    public class Items
    {
        public int idItem { get; set; }
        public string name { get; set; }
        public string game { get; set; }
        public int quantity { get; set; }
        public int idUser { get; set; }
        public string properties { get; set; }
        public string expirationDate { get; set; }
    }
}
