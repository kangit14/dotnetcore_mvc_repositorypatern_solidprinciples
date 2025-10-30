using RepositoryPatern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatern.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product? GetProduct(int id);
        void CreateProduct(Product product);
        void EditProduct(Product product);
        void RemoveProduct(int id);
    }
}
