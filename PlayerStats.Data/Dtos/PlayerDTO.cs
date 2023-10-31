using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.Data.Dtos
{
    public class PlayerDTO : BaseDTO
    {
        public string Username { get; set; } = null!;
        public int Wins { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int Rating { get; set; }
    }
}
