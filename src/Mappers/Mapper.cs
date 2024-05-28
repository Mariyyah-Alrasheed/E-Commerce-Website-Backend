using AutoMapper;
using Hanan_csharp_backend_teamwork.src.DTOs;
using Hanan_csharp_backend_teamwork.src.Entities;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Mappers;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Stock, StockCreateDto>();
        CreateMap<StockCreateDto, Stock>();

        CreateMap<Address, AddressDTO>();
        CreateMap<AddressDTO, Address>();
        CreateMap<AddressCreateDTO, Address>();
        CreateMap<Address, AddressCreateDTO>();




        CreateMap<Order, OrderCreateDTO>();
        CreateMap<OrderCreateDTO, Order>();

        CreateMap<CheckoutDto, Order>();
        CreateMap<CheckoutDto, OrderItem>();
        CreateMap<CheckoutDto, OrderCreateDTO>();
        CreateMap<OrderCreateDTO, Order>();
        CreateMap<OrderCreateDTO, OrderItem>();
        CreateMap<OrderCreateDTO, CheckoutDto>();
        CreateMap<OrderItem, CheckoutDto>();
        CreateMap<OrderItem, OrderCreateDTO>();
        CreateMap<OrderItem, Order>();
        CreateMap<Order, CheckoutDto>();
        CreateMap<Order, CheckoutDto>();
        CreateMap<Order, CheckoutDto>();

        CreateMap<Product, ProductReadDTO>();
        CreateMap<ProductReadDTO, Product>();
        CreateMap<ProductReadDTO, ProductDTO>();
        CreateMap<ProductDTO, ProductReadDTO>();
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
        CreateMap<ProductUpdateDTO, Product>()
             .ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));


        CreateMap<User, UserReadDto>();
        CreateMap<UserReadDto, User>();
        CreateMap<UserCreateDto, User>();
        CreateMap<AddressDTO, Address>();

        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<Category, CategoryReadDto>();
        CreateMap<CategoryReadDto, Category>();
        CreateMap<CategoryReadDto, CategoryCreateDto>();
        CreateMap<CategoryCreateDto, CategoryReadDto>();
    }
}
