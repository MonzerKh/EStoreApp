namespace EStoreWebApi.AppCore.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
