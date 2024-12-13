namespace EStoreWebApi.AppCore.Entities;

public class Customer
{
    public int Id  { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerSorName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhonNumber { get; set; }
    public string? Email { get; set; }
    public List<Invoice> Invoices { get; set; }



}
