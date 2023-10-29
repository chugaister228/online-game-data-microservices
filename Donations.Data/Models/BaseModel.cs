using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Data.Models
{
    public class BaseModel
    {
        public Guid ID { get; set; }
        public BaseModel() { ID = Guid.NewGuid(); }
    }
}
