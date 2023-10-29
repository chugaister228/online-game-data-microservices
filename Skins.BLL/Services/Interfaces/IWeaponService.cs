using Skins.Data.Dtos;
using Skins.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.BLL.Services.Interfaces
{
    public interface IWeaponService
    {
        Task<IBaseResponse<IEnumerable<WeaponDTO>>> GetAll();
        Task<IBaseResponse<string>> Insert(WeaponDTO modelDto);
        Task<IBaseResponse<string>> DeleteById(Guid id);
    }
}
