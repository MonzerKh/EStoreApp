namespace EStoreWebApi.AppCore.DomainDto.InvoiceDetail
{
    public class InvoiceDetailInsDto
    {
        public int? InvoiceId { get; set; }
        public int? ProductId { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? Discount { get; set; }
        public int amount { get; set; }

    }
}
