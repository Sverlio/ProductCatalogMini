using ProductCatalogMini.Services.DTOs.Suppliers;

namespace ProductCatalogMini.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<List<SupplierListDto>> GetAllAsync();
        Task CreateAsync(CreateSupplierDto dto);
    }
}