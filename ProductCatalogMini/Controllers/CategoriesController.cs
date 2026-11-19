using Microsoft.AspNetCore.Mvc;
using ProductCatalogData.Entities;
using ProductCatalogMini.Services.Interfaces;

namespace ProductCatalogMini.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ModelState.Remove(nameof(Category.Products));

            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
    }
}