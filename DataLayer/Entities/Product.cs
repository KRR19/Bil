using System;
using System.ComponentModel.DataAnnotations;

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
