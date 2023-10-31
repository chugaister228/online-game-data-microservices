using PlayerStats.DAL.Repositories.Interfaces;
using PlayerStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.DAL.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(PlayerStatsContext databaseContext) : base(databaseContext)
        {
        }
    }
}
