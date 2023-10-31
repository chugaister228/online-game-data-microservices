using AutoMapper;
using PlayerStats.Data.Dtos;
using PlayerStats.Data.Models;

namespace PlayerStats.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Friend, FriendDTO>();
            CreateMap<FriendDTO, Friend>();

            CreateMap<Player, PlayerDTO>();
            CreateMap<PlayerDTO, Player>();

            CreateMap<Violation, ViolationDTO>();
            CreateMap<ViolationDTO, Violation>();
        }
    }
}
