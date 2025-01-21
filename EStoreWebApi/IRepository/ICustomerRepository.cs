using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.IRepository
{
    public interface ICustomerRepository 
    {
        public int Insert(CustomerInsDto cust);
        public bool? Update(CustomerUpdDto cust);
        public List<Customer> Get(CustomerFilter? filter);
        public bool? Delete(int Id);
    }
}
