using System;
using System.Collections.Generic;

namespace TestDevWebService.Models
{
    public class Property
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int IdItem { get; set; }

        public virtual Item Item { get; set; }
    }
}
