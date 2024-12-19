namespace EStoreWebApi.AppCore.Entities;

public class Invoice : BaseEntity<int>
{
    public DateTime? InvoiceDate { get; set; }
    public decimal? InvoiceTotal { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public string? InvoiceNote { get; set; }

    public List<InvoiceDetail>? InvoiceDetails { get; set; }


}



