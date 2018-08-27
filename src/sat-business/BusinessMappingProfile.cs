using AutoMapper;
using sat_business.DTOs;

namespace sat_business
{
    public class BusinessMappingProfile : Profile
    {
        public BusinessMappingProfile()
        {
            CreateMap<SteamApiWrapper.Models.PlayerSummaries.Player, PlayerProfileDTO>()
                .ForMember(dest => dest.AvatarFull, opt => opt.MapFrom(src => src.avatarfull))
                .ForMember(dest => dest.PersonaName, opt => opt.MapFrom(src => src.personaname))
                .ForMember(dest => dest.ProfileUrl, opt => opt.MapFrom(src => src.profileurl))
                .ForMember(dest => dest.RealName, opt => opt.MapFrom(src => src.profileurl ?? "Not Found"))
                .ForMember(dest => dest.SteamId, opt => opt.MapFrom(src => long.Parse(src.steamid)));

            CreateMap<sat_dal.Models.PlayerProfile, PlayerProfileDTO>().ReverseMap();
        }
    }
}
