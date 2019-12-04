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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public List<CategoryModel> GetAll()
        {
            List<CategoryModel> categoryModel = _service.GetAll();
            return categoryModel;
        }

        [HttpGet("Get/{Id}")]
        public CategoryModel Get(Guid id)
        {
            CategoryModel categoryModel = _service.GetById(id);
            return categoryModel;
        }

        [HttpPost("Create")]
        public async Task<ResponseModel> Create([FromBody] CategoryModel categoryModel)
        {
            ResponseModel response = await _service.Create(categoryModel);
            return response;
        }

        [HttpPost("Update")]
        public async Task<ResponseModel> Update([FromBody] CategoryModel categoryModel)
        {
            ResponseModel response = await _service.Update(categoryModel);
            return response;
        }

        [HttpPost("Delete")]
        public async Task<ResponseModel> Delete(CategoryModel item)
        {
            ResponseModel response = await _service.Delete(item);
            return response;
        }
    }
}