using Donations.DAL.Repositories.Interfaces;
using Donations.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DonationsContext databaseContext) : base(databaseContext)
        {
        }
    }
}
