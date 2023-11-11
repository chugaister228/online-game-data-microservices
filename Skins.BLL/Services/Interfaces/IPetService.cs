using Skins.Data.Dtos;
using Skins.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.BLL.Services.Interfaces
{
    public interface IPetService
    {
        Task<IBaseResponse<PetDTO>> GetById(Guid id);
        Task<IBaseResponse<IEnumerable<PetDTO>>> GetAll();
        Task<IBaseResponse<string>> Insert(PetDTO modelDto);
        Task<IBaseResponse<string>> DeleteById(Guid id);
    }
}
