namespace EStoreWebApi.AppCore.Entities;

public class InvoiceDetail
{
    public int Id { get; set; }
    public int? InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public int? ProductId { get; set; }
    public Product Product { get; set; }
    public decimal? ProductPrice { get; set; }
    public decimal? Discount { get; set; }
    public int amount { get; set; }
}
