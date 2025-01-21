using AutoMapper;
using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using EStoreWebApi.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EStoreWebApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext appContext;
        private readonly IMapper mapper;

        public CustomerRepository(AppDbContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        public bool? Delete(int Id)
        {
            var item = this.appContext.Customers.Find(Id);

            if (item == null)
            {
                return null;
            }

            this.appContext.Customers.Remove(item);

            return this.appContext.SaveChanges() > 1;

        }

        public List<Customer> Get(CustomerFilter? filter)
        {
            var query = this.appContext.Customers.AsQueryable();

            if (filter?.CustomerName != null)
            {
                query = query.Where(r => r.CustomerName.Contains(filter.CustomerName));
            }

            if (filter?.CustomerSorName != null)
            {
                query = query.Where(r => r.CustomerSorName == filter.CustomerSorName);
            }

            if (filter?.BirthDate != null)
            {
                query = query.Where(r => r.BirthDate == filter.BirthDate);
            }

            if (filter?.PhonNumber != null)
            {
                query = query.Where(r => r.PhonNumber == filter.PhonNumber);
            }

            if (filter?.Email != null)
            {
                query = query.Where(r => r.Email == filter.Email);
            }

            var qstring = query.ToQueryString();

            return query.ToList();
        }

        public int Insert(CustomerInsDto cust)
        {
            var item = mapper.Map<Customer>(cust);

            this.appContext.Customers.Add(item);

            this.appContext.SaveChanges();

            return item.Id;
        }

        public bool? Update(CustomerUpdDto cust)
        {
            var item = this.appContext.Customers.Find(cust.Id);

            if (item == null)
            {
                return null;
            }

            this.mapper.Map(cust, item);

            this.appContext.Customers.Update(item);
            return this.appContext.SaveChanges() > 1;

        }
    }
}
