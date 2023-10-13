using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.Data.Models
{
    public class Pet : BaseModel
    {
        public string KindOfAnimal { get; set; } = null!;

        public Guid CharacterID { get; set; }
        public Character Character { get; set; } = null!;
    }
}
