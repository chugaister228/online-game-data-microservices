using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Data.Dtos
{
    public class UserDTO : BaseDTO
    {
        public string Username { get; set; } = null!;
        public string CreditCardNumber { get; set; } = null!;
    }
}
