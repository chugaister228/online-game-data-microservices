using Donations.Data.Dtos;
using Donations.Data.Interfaces;

namespace Donations.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<UserDTO>> GetById(Guid id);
        Task<IBaseResponse<IEnumerable<UserDTO>>> GetAll();
        Task<IBaseResponse<string>> Insert(UserDTO modelDto);
        Task<IBaseResponse<string>> DeleteById(Guid id);
    }
}
