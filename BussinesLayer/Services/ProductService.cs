using BussinesLayer.Models;
using BussinesLayer.Services.Interfaces;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ResponseModel> Create(ProductModel productModel)
        {
            Product product = new Product();
            ResponseModel response = ProductValidation(productModel);

            if (!response.IsValid)
            {
                return response;
            }

            product.Name = productModel.Name;
            product.Category.Name = productModel.Category;

            bool isCreate = await _productRepository.Create(product);

            if (!isCreate)
            {
                response.IsValid = false;
                response.Message = "Sorry, the product could not be created.";
                return response;
            }

            response.IsValid = true;
            response.Message = "Product Created.";

            return response;
        }

        public async Task<ResponseModel> Delete(ProductModel item)
        {
            Product product = new Product();
            ResponseModel response = new ResponseModel();

            product.Id = item.Id;
            product.Name = item.Name;
            product.Category.Name = item.Category;

            bool isDelete = await _productRepository.Delete(product);

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

        public List<ProductModel> GetAll()
        {
            List<Product> product = _productRepository.GetAll();
            List<ProductModel> productModels = new List<ProductModel>();

            foreach (var item in product)
            {
                ProductModel productModel = new ProductModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category.Name
                };

                productModels.Add(productModel);
            }

            return productModels;
        }

        public ProductModel GetById(Guid id)
        {
            ProductModel productModel = new ProductModel();
            Product product = _productRepository.GetById(id);

            productModel.Id = product.Id;
            productModel.Name = product.Name;
            productModel.Category = product.Category.Name;

            return productModel;
        }

        public async Task<ResponseModel> Update(ProductModel productModel)
        {
            Product product = new Product();
            ResponseModel response = ProductValidation(productModel);

            if (!response.IsValid)
            {
                return response;
            }

            product.Name = productModel.Name;
            product.Category.Name = productModel.Category;

            bool isCreate = await _productRepository.Update(product);

            if (!isCreate)
            {
                response.IsValid = false;
                response.Message = "Sorry, the product could not be updated.";
                return response;
            }

            response.IsValid = true;
            response.Message = "Product updated.";

            return response;
        }

        private ResponseModel ProductValidation(ProductModel productModel)
        {
            ResponseModel response = new ResponseModel();

            productModel.Name.Trim();

            if (string.IsNullOrEmpty(productModel.Name))
            {
                response.IsValid = false;
                response.Message = "Product тame сannot иe empty";
                return response;
            }

            if (string.IsNullOrEmpty(productModel.Category))
            {
                response.IsValid = false;
                response.Message = "Product cannot be without category";
                return response;
            }

            return new ResponseModel();
        }
    }
}
