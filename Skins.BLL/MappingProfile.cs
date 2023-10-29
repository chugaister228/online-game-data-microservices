using AutoMapper;
using Skins.Data.Dtos;
using Skins.Data.Models;

namespace Skins.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Character, CharacterDTO>();
            CreateMap<CharacterDTO, Character>();

            CreateMap<Pet, PetDTO>();
            CreateMap<PetDTO, Pet>();

            CreateMap<Weapon, WeaponDTO>();
            CreateMap<WeaponDTO, Weapon>();
        }
    }
}
