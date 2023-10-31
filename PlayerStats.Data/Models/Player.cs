using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.Data.Models
{
    public class Player : BaseModel
    {
        public string Username { get; set; } = null!;
        public int Wins { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int Rating { get; set; }

        public ICollection<Violation> Violations { get; set; } = null!;
        public ICollection<Friend> Friends { get; set; } = null!;
    }
}
