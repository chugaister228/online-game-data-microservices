using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Data.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = null!;

        public ICollection<Donation> Donations { get; set; } = null!;
    }
}
