using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product GetById(Guid id);
        public Task<bool> Create(Product product);
        public Task<bool> Update(Product product);
        public Task<bool> Delete(Product item);
    }
}
