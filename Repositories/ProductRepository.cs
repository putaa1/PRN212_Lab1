using BusinessObject;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product) => ProductDAO.Instance.DeleteProduct(product);

        public Product GetProductById(int id) => ProductDAO.Instance.GetProductById(id);

        public List<Product> GetProducts() => ProductDAO.Instance.GetProducts().ToList();

        public void SaveProduct(Product product) => ProductDAO.Instance.SaveProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
