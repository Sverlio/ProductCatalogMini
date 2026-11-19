using Microsoft.EntityFrameworkCore;
using ProductCatalogData.Database;
using ProductCatalogData.Entities;
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

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
    }
}