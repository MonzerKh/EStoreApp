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

//public class Invoice : BaseEntity<int>
//{
//    public DateTime? InvoiceDate { get; set; }
//    public int CustomerId { get; set; }
//    public Customer Customer { get; set; }
//    public string? InvoiceNote { get; set; }
//    public List<InvoiceDetail>? InvoiceDetails { get; set; }
//}

//public class InvoiceDetail : BaseEntity<int>
//{
//    public int? InvoiceId { get; set; }
//    public Invoice Invoice { get; set; }
//    public int? ProductId { get; set; }
//    public Product Product { get; set; }
//    public decimal? ProductPrice { get; set; }
//    public decimal? Discount { get; set; }
//    public int amount { get; set; }
//}

//public class Customer : BaseEntity<int>
//{
//    public string? CustomerName { get; set; }
//    public string? CustomerSorName { get; set; }
//    public DateTime? BirthDate { get; set; }
//    public string? PhonNumber { get; set; }
//    public string? Email { get; set; }
//    public List<Invoice>? Invoices { get; set; }
//}
