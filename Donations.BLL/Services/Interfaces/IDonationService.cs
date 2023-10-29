using Donations.Data.Dtos;
using Donations.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.BLL.Services.Interfaces
{
    public interface IDonationService
    {
        Task<IBaseResponse<IEnumerable<DonationDTO>>> GetAll();
        Task<IBaseResponse<string>> Insert(DonationDTO modelDto);
        Task<IBaseResponse<string>> DeleteById(Guid id);
    }
}
