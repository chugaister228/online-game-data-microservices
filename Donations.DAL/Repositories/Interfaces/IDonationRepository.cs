using Donations.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.DAL.Repositories.Interfaces
{
    public interface IDonationRepository : IGenericRepository<Donation>
    {
    }
}
