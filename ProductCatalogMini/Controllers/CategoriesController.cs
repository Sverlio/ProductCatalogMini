using Microsoft.AspNetCore.Mvc;
using ProductCatalogMini.Services.DTOs.Categories;
using ProductCatalogMini.Services.Interfaces;
using ProductCatalogMini.ViewModels.Categories;

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
            var model = new CategoriesIndexViewModel
            {
                Categories = await _categoryService.GetAllAsync()
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new CreateCategoryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = new CreateCategoryDto
                {
                    Name = model.Name,
                    Description = model.Description
                };

                await _categoryService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}