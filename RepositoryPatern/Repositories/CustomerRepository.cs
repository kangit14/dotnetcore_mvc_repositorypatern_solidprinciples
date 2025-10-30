using RepositoryPatern.Data;
using RepositoryPatern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatern.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll() => _context.Customers.ToList();

        public Customer? GetById(int id) => _context.Customers.Find(id);

        public void Add(Customer customer) => _context.Customers.Add(customer);

        public void Update(Customer customer) => _context.Customers.Update(customer);

        public void Delete(int id)
        {
            var v_customer = _context.Customers.Find(id);
            if (v_customer != null) _context.Customers.Remove(v_customer);
        }

        public void Save() => _context.SaveChanges();
    }
}
