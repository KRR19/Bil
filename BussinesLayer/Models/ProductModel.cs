using System;

namespace BussinesLayer.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryModel Category { get; set; }
    }
}
