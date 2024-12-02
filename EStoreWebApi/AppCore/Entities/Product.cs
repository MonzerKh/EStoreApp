namespace EStoreWebApi.AppCore.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string? ProductionCountry { get; set; }
    public string? BarcodeCode { get; set;}
    public string? Brand { get; set;}
    public string? Description { get; set; }
    public int? Counter { get; set; }
    public List<ProductDetail> ProductDetails { get; set; }


    //public List<ProductDetail> ProductDetails { get; set; }
    //public int? ProductTypeId { get; set; }
    //public ProductType? productType { get; set; }

    //List<StoreProduct> StoreProducts { get; set; }

}
