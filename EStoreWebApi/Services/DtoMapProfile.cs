using AutoMapper;
using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.Entities;

namespace EStoreWebApi.Services;

public class DtoMapProfile : Profile
{
    public DtoMapProfile()
    {

        CreateMap<Customer, CustomerInsDto>();
        CreateMap<CustomerInsDto, Customer>();

        CreateMap<Customer, CustomerUpdDto>();
        CreateMap<CustomerUpdDto, Customer>();



    }
}
