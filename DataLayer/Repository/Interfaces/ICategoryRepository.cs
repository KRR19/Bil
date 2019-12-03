using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
        public Category GetById(Guid id);
        public Task<bool> Create(Category product);
        public Task<bool> Update(Category product);
        public Task<bool> Delete(Category item);
    }
}
