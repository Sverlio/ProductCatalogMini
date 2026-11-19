using Microsoft.AspNetCore.Mvc;
using ProductCatalogData.Entities;
using ProductCatalogMini.Services.Interfaces;

namespace ProductCatalogMini.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllAsync();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            ModelState.Remove(nameof(Supplier.Products));

            if (ModelState.IsValid)
            {
                await _supplierService.CreateAsync(supplier);
                return RedirectToAction(nameof(Index));
            }

            return View(supplier);
        }
    }
}