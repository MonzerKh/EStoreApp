namespace EStoreWebApi.AppCore.Entities;

public class ProductDetail
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }

}
