using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.Data.Models
{
    public class Character : BaseModel
    {
        public string RaceOfCharacter { get; set; } = null!;

        public Pet Pet { get; set; } = null!;

        public Weapon Weapon { get; set; } = null!;
    }
}
