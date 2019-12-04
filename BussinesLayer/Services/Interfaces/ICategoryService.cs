using BussinesLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        public List<CategoryModel> GetAll();
        public CategoryModel GetById(Guid id);
        public Task<ResponseModel> Create(CategoryModel product);
        public Task<ResponseModel> Update(CategoryModel product);
        public Task<ResponseModel> Delete(CategoryModel item);
    }
}
