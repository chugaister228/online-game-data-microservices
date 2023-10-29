using Donations.DAL.Repositories.Interfaces;
using Donations.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.DAL.Repositories
{
    public class DonationRepository : GenericRepository<Donation>, IDonationRepository
    {
        public DonationRepository(DonationsContext databaseContext) : base(databaseContext)
        {
        }
    }
}
