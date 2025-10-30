using RepositoryPatern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatern.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetProducts();
        Customer? GetProduct(int id);
        void CreateProduct(Customer customer);
        void EditProduct(Customer customer);
        void RemoveProduct(int id);
    }
}
