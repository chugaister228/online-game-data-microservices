using PlayerStats.DAL.Repositories.Interfaces;
using PlayerStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.DAL.Repositories
{
    public class ViolationRepository : GenericRepository<Violation>, IViolationRepository
    {
        public ViolationRepository(PlayerStatsContext databaseContext) : base(databaseContext)
        {
        }
    }
}
