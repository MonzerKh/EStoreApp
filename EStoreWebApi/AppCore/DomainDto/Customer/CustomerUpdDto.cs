using System.ComponentModel.DataAnnotations;

namespace EStoreWebApi.AppCore.DomainDto;

public class CustomerUpdDto : InvoiceInsDto
{
    [Required(ErrorMessage ="Id Is Requird faild")]
    public int? Id { get; set; }
}
