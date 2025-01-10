using EStoreWebApi.AppCore.Entities;

namespace EStoreWebApi.AppCore.DomainDto.Customer
{
    public class CustomerFilter
    {
        public string? CustomerName { get; set; }
        public string? CustomerSorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhonNumber { get; set; }
        public string? Email { get; set; }


    }
}

