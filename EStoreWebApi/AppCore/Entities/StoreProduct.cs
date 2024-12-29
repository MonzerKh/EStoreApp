namespace EStoreWebApi.AppCore.Entities
{
    public class StoreProduct : BaseEntity<int>
    {  
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }

    }
}
