using PlayerStats.Data.Dtos;
using PlayerStats.Data.Interfaces;

namespace PlayerStats.BLL.Services.Interfaces
{
    public interface IViolationService
    {
        Task<IBaseResponse<IEnumerable<ViolationDTO>>> GetAll();
        Task<IBaseResponse<string>> Insert(ViolationDTO modelDto);
        Task<IBaseResponse<string>> DeleteById(Guid id);
    }
}
