namespace EStoreWebApi.AppCore.Entities;

public class Invoice
{
    public int Id { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public decimal? InvoiceTotal { get; set; }
    public List<InvoiceDetail> InvoiceDetails { get; set; }
    public int CustomerId { get; set; }

    public string? InvoiceNote { get; set; }

    public Customer Customer { get; set; }
}



