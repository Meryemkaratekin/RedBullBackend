using System.Collections.Generic;
using System.Linq;
using RedBullService.Models;

namespace RedBullService.Services
{
    public interface IProductService
    {
        List<Products> GetAllProducts();
        Products GetProductById(int id);
        void CreateProduct(Products product);
        void UpdateProduct(Products existingProduct, Products updatedProduct);
        void DeleteProduct(Products product);
    }

  
}