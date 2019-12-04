using BussinesLayer.Models;
using BussinesLayer.Services.Interfaces;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ResponseModel> Create(CategoryModel categoryModel)
        {
            Category category = new Category();
            ResponseModel response = CategoryValidation(categoryModel);

            if (!response.IsValid)
            {
                return response;
            }

            category.Name = categoryModel.Name;

            bool isCreate = await _categoryRepository.Create(category);

            if (!isCreate)
            {
                response.IsValid = false;
                response.Message = "Sorry, the category could not be created.";
                return response;
            }

            response.IsValid = true;
            response.Message = "Category Created.";

            return response;
        }

        public async Task<ResponseModel> Delete(CategoryModel item)
        {
            Category category = new Category();
            ResponseModel response = new ResponseModel();

            category.Id = item.Id;
            category.Name = item.Name;

            bool isDelete = await _categoryRepository.Delete(category);

            if (!isDelete)
            {
                response.IsValid = false;
                response.Message = "Item not deleted";
                return response;
            }

            response.IsValid = true;
            response.Message = "Item removed";

            return response;
        }

        public List<CategoryModel> GetAll()
        {
            List<Category> categorys = _categoryRepository.GetAll();
            List<CategoryModel> categoryModels = new List<CategoryModel>();

            foreach (var item in categorys)
            {
                CategoryModel categoryModel = new CategoryModel
                {
                    Id = item.Id,
                    Name = item.Name,
                };

                categoryModels.Add(categoryModel);
            }

            return categoryModels;
        }

        public CategoryModel GetById(Guid id)
        {
            CategoryModel categoryModel = new CategoryModel();
            Category category = _categoryRepository.GetById(id);

            categoryModel.Id = category.Id;
            categoryModel.Name = category.Name;
            

            return categoryModel;
        }

        public async Task<ResponseModel> Update(CategoryModel categoryModel)
        {
            Category category = new Category();
            ResponseModel response = CategoryValidation(categoryModel);

            if (!response.IsValid)
            {
                return response;
            }

            category.Id = categoryModel.Id;
            category.Name = categoryModel.Name;

            bool isCreate = await _categoryRepository.Update(category);

            if (!isCreate)
            {
                response.IsValid = false;
                response.Message = "Sorry, the category could not be updated.";
                return response;
            }

            response.IsValid = true;
            response.Message = "Category updated.";

            return response;
        }

        private ResponseModel CategoryValidation(CategoryModel categoryModel)
        {
            ResponseModel response = new ResponseModel();

            categoryModel.Name.Trim();

            if (string.IsNullOrEmpty(categoryModel.Name))
            {
                response.IsValid = false;
                response.Message = "Category name сannot иe empty";
                return response;
            }            

            return new ResponseModel() { IsValid = true};
        }
    }
}
