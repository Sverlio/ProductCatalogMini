using ProductCatalogData.Entities;

namespace ProductCatalogMini.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAllAsync();
        Task CreateAsync(Supplier supplier);
    }
}