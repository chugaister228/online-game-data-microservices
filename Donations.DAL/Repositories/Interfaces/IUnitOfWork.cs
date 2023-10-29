using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IDonationRepository DonationRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }

        Task SaveChangesAsync();
    }
}
