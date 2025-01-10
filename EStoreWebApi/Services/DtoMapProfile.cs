using AutoMapper;
using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.DomainDto.InvoiceDetail;
using EStoreWebApi.AppCore.DomainDto.Product;
using EStoreWebApi.AppCore.DomainDto.ProductDetail;
using EStoreWebApi.AppCore.DomainDto.ProductType;
using EStoreWebApi.AppCore.DomainDto.Receipt;
using EStoreWebApi.AppCore.DomainDto.Store;
using EStoreWebApi.AppCore.DomainDto.StoreProducts;
using EStoreWebApi.AppCore.DomainDto.Users;
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

        CreateMap<Invoice,InvoiceInsDto>();
        CreateMap<InvoiceInsDto, Invoice>();

        CreateMap<InvoiceDetail, InvoiceDetailInsDto>();
        CreateMap<InvoiceDetailInsDto, InvoiceDetail>();

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
