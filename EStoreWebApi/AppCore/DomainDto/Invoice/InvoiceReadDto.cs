
using EStoreWebApi.AppCore.Entities;

namespace EStoreWebApi.AppCore.DomainDto;



public class InvoiceReadDto
{
    public int Id { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? InvoiceNote { get; set; }

    public decimal? InvoiceTotal { get; set; }
    public decimal? TotalProductPrice { get; set; }
    public decimal? TotalDiscount { get; set; }

    public List<InvoiceDetail>? InvoiceDetails { get; set; }
}
