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
    public class CharacterService : ICharacterService
    {
        private IUnitOfWork _unitOfWork;

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IBaseResponse<IEnumerable<CharacterDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<string>> UpdateById(Guid id, CharacterDTO characterDto)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<string>> Insert(CharacterDTO characterDto)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<string>> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
