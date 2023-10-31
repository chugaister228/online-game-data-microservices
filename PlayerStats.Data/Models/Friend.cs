using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.Data.Models
{
    public class Friend : BaseModel
    {
        public string Friendname { get; set; } = null!;

        public Guid PlayerID { get; set; }
        public Player Player { get; set; } = null!;
    }
}
