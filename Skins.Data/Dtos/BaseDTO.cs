using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.Data.Dtos
{
    public class BaseDTO
    {
        public Guid ID { get; set; }

        public string Name { get; set; } = null!;

        public int Rarity { get; set; }
    }
}
