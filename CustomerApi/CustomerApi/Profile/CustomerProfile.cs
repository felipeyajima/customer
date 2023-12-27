using CustomerApi.Data.Dto;
using CustomerApi.Models;
using AutoMapper;

namespace CustomerApi.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<Customer, UpdateCustomerDto>();
            CreateMap<Customer, ReadCustomerDto>();
        
        }    
    }
}
