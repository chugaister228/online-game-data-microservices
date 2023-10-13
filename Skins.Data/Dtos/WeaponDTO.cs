using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.Data.Dtos
{
    public class WeaponDTO : BaseDTO
    {
        public string TypeOfWeapon { get; set; } = null!;

        public Guid CharacterID { get; set; }
    }
}
