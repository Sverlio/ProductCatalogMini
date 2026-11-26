using Microsoft.EntityFrameworkCore;
using ProductCatalogData.Database;
using ProductCatalogData.Entities;
using ProductCatalogMini.Services.DTOs.Categories;
using ProductCatalogMini.Services.Interfaces;

namespace ProductCatalogMini.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryListDto>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryListDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
    }
}