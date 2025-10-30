using RepositoryPatern.Entities;
using RepositoryPatern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatern.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Customer> GetProducts() => _repo.GetAll();

        public Customer? GetProduct(int id) => _repo.GetById(id);

        public void CreateProduct(Customer customer)
        {
            // business logic validation
            if (string.IsNullOrEmpty(customer.Name))
                throw new Exception("Invalid name");
            _repo.Add(customer);
            _repo.Save();
        }

        public void EditProduct(Customer customer)
        {
            _repo.Update(customer);
            _repo.Save();
        }

        public void RemoveProduct(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
