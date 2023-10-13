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
        Task<IBaseResponse<IEnumerable<PetDTO>>> GetAll();
        Task<IBaseResponse<string>> UpdateById(Guid id, PetDTO petDto);
        Task<IBaseResponse<string>> Insert(PetDTO petDto);
        Task<IBaseResponse<string>> DeleteById(Guid id);
    }
}
