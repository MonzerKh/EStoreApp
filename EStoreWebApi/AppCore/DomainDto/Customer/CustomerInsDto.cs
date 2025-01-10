using System.ComponentModel.DataAnnotations;

namespace EStoreWebApi.AppCore.DomainDto;

public class CustomerInsDto
{
    public string? CustomerName { get; set; }
    public string? CustomerSorName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhonNumber { get; set; }
    public string? Email { get; set; }

}
