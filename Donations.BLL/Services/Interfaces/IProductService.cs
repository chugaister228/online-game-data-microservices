using Donations.Data.Dtos;
using Donations.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<ProductDTO>> GetById(Guid id);
        Task<IBaseResponse<IEnumerable<ProductDTO>>> GetAll();
        Task<IBaseResponse<string>> Insert(ProductDTO modelDto);
        Task<IBaseResponse<string>> DeleteById(Guid id);
    }
}
