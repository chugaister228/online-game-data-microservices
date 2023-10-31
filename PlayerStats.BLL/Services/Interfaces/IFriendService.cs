using PlayerStats.Data.Dtos;
using PlayerStats.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.BLL.Services.Interfaces
{
    public interface IFriendService
    {
        Task<IBaseResponse<IEnumerable<FriendDTO>>> GetAll();
        Task<IBaseResponse<string>> Insert(FriendDTO modelDto);
        Task<IBaseResponse<string>> DeleteById(Guid id);
    }
}
