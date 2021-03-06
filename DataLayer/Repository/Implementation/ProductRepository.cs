﻿using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext = DataLayer.ApplicationContext.AppContext;

namespace DataLayer.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppContext _context;
        public ProductRepository(AppContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            List<Product> product = _context.Products.Include(x => x.Category).ToList();

            return product;
        }

        public Product GetById(Guid id)
        {
            Product product = _context.Products.Where(x => x.Id == id).Include(i => i.Category).FirstOrDefault();

            return product;
        }

        public async Task<bool> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Product item)
        {
            _context.Products.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
