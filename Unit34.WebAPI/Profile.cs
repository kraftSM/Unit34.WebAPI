using AutoMapper;
using Unit34.WebAPI.Configuration;
using Unit34.WebAPI.Contracts;

namespace Unit34.WebAPI
{
    public class MappingProfile : Profile
    { 
    /// <summary>
    /// В конструкторе настроим соответствие сущностей при маппинге
    /// </summary>
   public MappingProfile()
        {
        CreateMap<Address, AddressInfo>();
        CreateMap<HomeOptions, InfoResponse>()
            .ForMember(m => m.AddressInfo,
                opt => opt.MapFrom(src => src.Address));
        }
    }
}
