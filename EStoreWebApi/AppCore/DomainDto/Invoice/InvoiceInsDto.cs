
using System.ComponentModel.DataAnnotations;

namespace EStoreWebApi.AppCore.DomainDto;

public class InvoiceInsDto
{
    public DateTime? InvoiceDate { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than 0.")]
    public decimal? InvoiceTotal { get; set; }

    [Required(ErrorMessage ="Customer Id Is Required")]
    public int? CustomerId { get; set; }
    public string? InvoiceNote { get; set; }
}
