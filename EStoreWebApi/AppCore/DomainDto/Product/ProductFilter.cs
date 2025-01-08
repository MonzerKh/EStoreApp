namespace EStoreWebApi.AppCore.DomainDto.Product
{
    public class ProductFilter
    {
        public string ProductName { get; set; }
        public string? ProductionCountry { get; set; }
        public string? BarcodeCode { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public int? Counter { get; set; }
    }
}
