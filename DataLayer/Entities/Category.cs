using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
