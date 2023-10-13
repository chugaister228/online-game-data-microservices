using Skins.BLL.Services.Interfaces;
using Skins.DAL.Repositories.Interfaces;
using Skins.Data.Dtos;
using Skins.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.BLL.Services
{
    public class WeaponService : IWeaponService
    {
        private IUnitOfWork _unitOfWork;

        public WeaponService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IBaseResponse<IEnumerable<WeaponDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<string>> UpdateById(Guid id, WeaponDTO weaponDto)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<string>> Insert(WeaponDTO weaponDto)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<string>> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
