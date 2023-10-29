using AutoMapper;
using Donations.Data.Dtos;
using Donations.Data.Models;

namespace Donations.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Donation, DonationDTO>();
            CreateMap<DonationDTO, Donation>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
