using AutoMapper;
using MS.Customer.Application.Abstraction.src.Customer.Contracts;

namespace MS.Customer.Infastructure.src.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Domain.Customer>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Domain.Customer, CustomerDto>();

            CreateMap<CustomerUpdateDto, Domain.Customer>();
        }
    }
}
