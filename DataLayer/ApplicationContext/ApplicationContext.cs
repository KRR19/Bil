using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ApplicationContext
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {

        }
    }
}
