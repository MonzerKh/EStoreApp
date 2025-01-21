using EStoreWebApi.AppCore.Entities;

namespace EStoreWebApi.AppCore.DomainDto;

public class InvoiceDetailFilter
{
    public int? Id { get; set; }
    public int? InvoiceId { get; set; }
    
    public DateTime? InvoiceDate { get; set; }
    public string? InvoiceNote { get; set; }
    public string? ProductName { get; set; }
    public string? Brand { get; set; }
    public string? Description { get; set; }
    public decimal? ProductPrice { get; set; }
    public decimal? Discount { get; set; }
    public int? amount { get; set; }
    public decimal? TotalPrice { get; set; }
}
