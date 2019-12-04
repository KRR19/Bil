using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
