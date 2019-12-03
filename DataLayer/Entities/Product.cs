using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
