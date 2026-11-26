namespace ProductCatalogMini.Services.DTOs.Suppliers
{
    public class CreateSupplierDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}