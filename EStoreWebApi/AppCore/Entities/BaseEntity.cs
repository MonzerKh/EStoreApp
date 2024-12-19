namespace EStoreWebApi.AppCore.Entities;

public class BaseEntity <T>
{
    public T Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int? CreateByUserId { get; set; }
    public int? UpdateByUserId { get; set; }
}
