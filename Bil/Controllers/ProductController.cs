using BussinesLayer.Models;
using BussinesLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public List<ProductModel> GetAll()
        {
            List<ProductModel> productModels = _service.GetAll();
            return productModels;
        }

        [HttpGet("Get/{Id}")]
        public ProductModel Get(Guid id)
        {
            ProductModel productModel = _service.GetById(id);
            return productModel;
        }

        [HttpPost("Create")]
        public async Task<ResponseModel> Create([FromBody] ProductModel productModel)
        {
            ResponseModel response = await _service.Create(productModel);
            return response;
        }

        [HttpPost("Update")]
        public async Task<ResponseModel> Update([FromBody] ProductModel productModel)
        {
            ResponseModel response = await _service.Update(productModel);
            return response;
        }

        [HttpPost("Delete")]
        public async Task<ResponseModel> Delete(ProductModel item)
        {
            ResponseModel response = await _service.Delete(item);
            return response;
        }
    }
}