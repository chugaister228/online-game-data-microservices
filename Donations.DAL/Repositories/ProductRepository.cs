using Donations.DAL.Repositories.Interfaces;
using Donations.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DonationsContext databaseContext) : base(databaseContext)
        {
        }
    }
}
