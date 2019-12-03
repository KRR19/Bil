using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        
    }
}
