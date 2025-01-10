

namespace EStoreWebApi.AppCore.DomainDto;

public class ProductInsDto
{
    public string ProductName { get; set; }
    public string? ProductionCountry { get; set; }
    public string? BarcodeCode { get; set; }
    public string? Brand { get; set; }
    public string? Description { get; set; }
    public int? Counter { get; set; }
}
