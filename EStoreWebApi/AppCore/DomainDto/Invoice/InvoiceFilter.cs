namespace EStoreWebApi.AppCore.DomainDto;

public class InvoiceFilter
{
    public DateTime? InvoiceDate { get; set; }
    public decimal? InvoiceTotal { get; set; }
    public decimal? InvoiceTotalMin { get; set; }
    public decimal? InvoiceTotalMax { get; set; }
    public int? CustomerId { get; set; }
    public int? InvoiceId { get; set; }
    public string? InvoiceNote { get; set; }
    public string? CustomerName { get; set; }
}
