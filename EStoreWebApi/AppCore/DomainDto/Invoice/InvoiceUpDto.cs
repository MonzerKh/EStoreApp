using System.ComponentModel.DataAnnotations;

namespace EStoreWebApi.AppCore.DomainDto;

public class InvoiceUpDto : InvoiceInsDto
{
    public int   Id { get; set; }
}
