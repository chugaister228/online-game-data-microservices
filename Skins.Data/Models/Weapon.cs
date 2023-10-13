using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.Data.Models
{
    public class Weapon : BaseModel
    {
        public string TypeOfWeapon { get; set; } = null!;

        public Guid CharacterID { get; set; }
        public Character Character { get; set; } = null!;
    }
}
