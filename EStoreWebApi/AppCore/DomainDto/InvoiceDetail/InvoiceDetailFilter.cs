using EStoreWebApi.AppCore.Entities;

namespace EStoreWebApi.AppCore.DomainDto.InvoiceDetail
{
    public class InvoiceDetailFilter
    {
        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? Discount { get; set; }
        public int amount { get; set; }
    }
}
