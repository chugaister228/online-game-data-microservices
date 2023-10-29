using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Data.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; } = null!;
        public string CreditCardNumber { get; set; } = null!;

        public ICollection<Donation> Donations { get; set; } = null!;
    }
}
