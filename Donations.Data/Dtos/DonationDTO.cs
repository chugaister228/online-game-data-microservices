using Donations.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Data.Dtos
{
    public class DonationDTO : BaseDTO
    {
        public int Sum { get; set; }
        public DateTime Date { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
    }
}
