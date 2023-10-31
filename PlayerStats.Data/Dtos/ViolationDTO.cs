using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.Data.Dtos
{
    public class ViolationDTO : BaseDTO
    {
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Guid PlayerID { get; set; }
    }
}
