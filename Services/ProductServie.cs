using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServie : IProductService
    {

        private readonly IProductRepository productRepository;

        public ProductServie()
        {
            productRepository = new ProductRepository();
        }

        public void DeleteProduct(Product product) => productRepository.DeleteProduct(product);

        public Product GetProductById(int id) => productRepository.GetProductById(id);

        public List<Product> GetProducts() => productRepository.GetProducts();

        public void SaveProduct(Product product) => productRepository.SaveProduct(product);

        public void UpdateProduct(Product product) => productRepository.UpdateProduct(product);
    }
}
