namespace EStoreWebApi.AppCore.Entities
{
    public class ProductType : BaseEntity<int>
    {

        public string TypeName { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
