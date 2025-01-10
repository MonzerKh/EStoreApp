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

        CreateMap<Invoice, InvoiceInsDto>();
        CreateMap<InvoiceInsDto, Invoice>();

        CreateMap<InvoiceDetail, InvoiceDetailInsDto>();
        CreateMap<InvoiceDetailInsDto, InvoiceDetail>();

        CreateMap<Invoice, InvoiceReadDto>()
            .ForMember(dest =>
                dest.TotalProductPrice,
                opt => opt.MapFrom(r => r.InvoiceDetails!.Sum(x => x.ProductPrice)))
            .ForMember(dest =>
                dest.TotalDiscount,
                opt => opt.MapFrom(r => r.InvoiceDetails!.Sum(r => r.Discount)))
            .ForMember(dest =>
                dest.InvoiceTotal,
                opt => opt.MapFrom(r => r.InvoiceDetails!.Sum(x => x.ProductPrice - x.Discount)))
            .ForMember(dest =>
            dest.CustomerName,
            opt => opt.MapFrom(r => r.Customer.CustomerName + " " + r.Customer.CustomerSorName))

            .ForMember(dest=>
                dest.InvoiceDetails,
                opt => opt.MapFrom(r=>r.InvoiceDetails))
            ;
        CreateMap<InvoiceReadDto, Invoice>();

        CreateMap<Product, ProductInsDto>();
        CreateMap<ProductInsDto, Product>();

        CreateMap<ProductDetail, ProductDetailInsDto>();
        CreateMap<ProductDetailInsDto, ProductDetail>();

        CreateMap<ProductType, ProductTypeInsDto>();
        CreateMap<ProductTypeInsDto, ProductType>();

        CreateMap<Receipt, ReceiptInsDto>();
        CreateMap<ReceiptInsDto, Receipt>();

        CreateMap<Store, StoreInsDto>();
        CreateMap<StoreInsDto, Store>();

        CreateMap<StoreProduct, StoreProductsInsDto>();
        CreateMap<StoreProductsInsDto, StoreProduct>();

        CreateMap<User, UsersInsDto>();
        CreateMap<UsersInsDto, User>();








    }
}
