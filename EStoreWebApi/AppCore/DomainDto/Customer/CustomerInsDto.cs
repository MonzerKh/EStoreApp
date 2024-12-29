using System.ComponentModel.DataAnnotations;

namespace EStoreWebApi.AppCore.DomainDto;

public class InvoiceInsDto
{
    public string? CustomerName { get; set; }
    public string? CustomerSorName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhonNumber { get; set; }
    public string? Email { get; set; }

    [Range(1,int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public decimal ProductPrice { get; set; }
}
