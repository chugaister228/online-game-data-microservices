using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.Data.Models
{
    public class Violation : BaseModel
    {
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Guid PlayerID { get; set; }
        public Player Player { get; set; } = null!;
    }
}
