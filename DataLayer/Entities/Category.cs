using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
