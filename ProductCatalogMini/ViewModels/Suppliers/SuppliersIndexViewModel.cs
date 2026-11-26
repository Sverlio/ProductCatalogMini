using ProductCatalogMini.Services.DTOs.Suppliers;

namespace ProductCatalogMini.ViewModels.Suppliers
{
    public class SuppliersIndexViewModel
    {
        public List<SupplierListDto> Suppliers { get; set; } = new();
    }
}