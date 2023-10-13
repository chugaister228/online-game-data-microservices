using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.Data.Dtos
{
    public class PetDTO : BaseDTO
    {
        public string KindOfAnimal { get; set; } = null!;

        public Guid CharacterID { get; set; }
    }
}
