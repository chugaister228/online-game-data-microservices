using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.Data.Models
{
    public abstract class BaseModel
    {
        public Guid ID { get; set; }

        public string Name { get; set; } = null!;

        public int Rarity { get; set; }

        public BaseModel() { ID = Guid.NewGuid(); }
    }
}
