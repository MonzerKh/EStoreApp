namespace EStoreWebApi.AppCore.Entities;

public class ProductDetail : BaseEntity<int>
{

    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string? Title { get; set; }
    public string? DetailContent { get; set; }
    public string? Description { get; set; }

}
