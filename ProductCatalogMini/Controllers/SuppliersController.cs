using Microsoft.AspNetCore.Mvc;
using ProductCatalogMini.Services.DTOs.Suppliers;
using ProductCatalogMini.Services.Interfaces;
using ProductCatalogMini.ViewModels.Suppliers;

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
            var model = new SuppliersIndexViewModel
            {
                Suppliers = await _supplierService.GetAllAsync()
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new CreateSupplierViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = new CreateSupplierDto
                {
                    CompanyName = model.CompanyName,
                    Email = model.Email,
                    Phone = model.Phone
                };

                await _supplierService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}