using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.Data.Dtos
{
    public class FriendDTO : BaseDTO
    {
        public string Friendname { get; set; } = null!;

        public Guid PlayerID { get; set; }
    }
}
