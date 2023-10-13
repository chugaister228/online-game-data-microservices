using Skins.DAL.Repositories.Interfaces;
using Skins.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.DAL.Repositories
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(SkinsContext databaseContext) : base(databaseContext)
        {
        }
    }
}
