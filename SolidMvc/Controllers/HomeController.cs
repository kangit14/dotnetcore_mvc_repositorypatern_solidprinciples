using Microsoft.AspNetCore.Mvc;
using RepositoryPatern.Entities;
using RepositoryPatern.Services;
using SolidMvc.Models;
using System.Diagnostics;

namespace SolidMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _service;

        public HomeController(ICustomerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var products = _service.GetProducts();
            return View(products);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _service.CreateProduct(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var product = _service.GetProduct(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _service.EditProduct(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            _service.RemoveProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
