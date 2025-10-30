using RepositoryPatern.Entities;
using RepositoryPatern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatern.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Product> GetProducts() => _repo.GetAll();

        public Product? GetProduct(int id) => _repo.GetById(id);

        public void CreateProduct(Product product)
        {
            // business logic validation
            if (string.IsNullOrEmpty(product.Name))
                throw new Exception("Invalid name");
            _repo.Add(product);
            _repo.Save();
        }

        public void EditProduct(Product product)
        {
            _repo.Update(product);
            _repo.Save();
        }

        public void RemoveProduct(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
