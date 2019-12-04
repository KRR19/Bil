using BussinesLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Interfaces
{
    public interface IProductService
    {
        public List<ProductModel> GetAll();
        public ProductModel GetById(Guid id);
        public Task<ResponseModel> Create(ProductModel product);
        public Task<ResponseModel> Update(ProductModel product);
        public Task<ResponseModel> Delete(ProductModel item);
    }
}
