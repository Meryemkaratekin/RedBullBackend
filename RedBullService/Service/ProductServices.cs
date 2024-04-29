using System.Collections.Generic;
using System.Linq;
using RedbullService.Models;
using RedBullService.Models;
using RedBullService.Services;

namespace RedbullService.Services
{
    public class ProductService : IProductService
    {
        private static List<Products> _products = new List<Products>();

        public List<Products> GetAllProducts()
        {
            return _products;
        }

        public Products GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.urunId == id);
        }

        public void CreateProduct(Products product)
        {
            _products.Add(product);
        }

        public void UpdateProduct(Products existingProduct, Products updatedProduct)
        {
            existingProduct.urunAdi = updatedProduct.urunAdi;
            existingProduct.aciklama = updatedProduct.aciklama;
            existingProduct.resimUrl = updatedProduct.resimUrl;
        }

        public void DeleteProduct(Products product)
        {
            _products.Remove(product);
        }
    }
}