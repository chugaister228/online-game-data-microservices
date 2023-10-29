using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Data.Models
{
    public class Donation : BaseModel
    {
        public int Sum { get; set; }
        public DateTime Date { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; } = null!;

        public Guid ProductID { get; set; }
        public Product Product { get; set; } = null!;
    }
}
