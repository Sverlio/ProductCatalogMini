using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductCatalogData.Enums;
using ProductCatalogMini.Services.DTOs.Products;
using ProductCatalogMini.Services.Interfaces;
using ProductCatalogMini.ViewModels.Products;

namespace ProductCatalogMini.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ProductsIndexViewModel
            {
                Products = await _productService.GetAllAsync()
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetDetailsByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdownsAsync();
            return View(new CreateProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = new CreateProductDto
                {
                    Name = model.Name,
                    Price = model.Price,
                    StockQuantity = model.StockQuantity,
                    Status = model.Status,
                    CategoryId = model.CategoryId,
                    SupplierId = model.SupplierId
                };

                await _productService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdownsAsync(model.CategoryId, model.SupplierId);
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var model = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Status = product.Status,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId
            };

            await PopulateDropdownsAsync(model.CategoryId, model.SupplierId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dto = new EditProductDto
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Price = model.Price,
                        StockQuantity = model.StockQuantity,
                        Status = model.Status,
                        CategoryId = model.CategoryId,
                        SupplierId = model.SupplierId
                    };

                    await _productService.UpdateAsync(dto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_productService.Exists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdownsAsync(model.CategoryId, model.SupplierId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetDetailsByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdownsAsync(int? selectedCategoryId = null, int? selectedSupplierId = null)
        {
            var (categories, suppliers) = await _productService.GetDropdownDataAsync();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", selectedCategoryId);
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "CompanyName", selectedSupplierId);
            ViewBag.Statuses = new SelectList(Enum.GetValues<ProductStatus>());
        }
    }
}