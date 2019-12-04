using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext = DataLayer.ApplicationContext.AppContext;

namespace DataLayer.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppContext _context;
        public CategoryRepository(AppContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = _context.Categories.ToList();

            return categories;
        }

        public Category GetById(Guid id)
        {
            Category category = _context.Categories.Find(id);

            return category;
        }

        public async Task<bool> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Category item)
        {
            _context.Categories.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
