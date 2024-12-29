
namespace EStoreWebApi.AppCore.DomainDto.Invoice;

public class InvoiceInsDto
{
    public DateTime? InvoiceDate { get; set; }
    public decimal? InvoiceTotal { get; set; }
    public int CustomerId { get; set; }

    public string? InvoiceNote { get; set; }


}
