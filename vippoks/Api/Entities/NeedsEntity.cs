using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vippoks.Api.Entities
{
    public class NeedsEntity
    {
        public int id { get; set; }
        public double minPrice { get; set; }
        public double maxPrice { get; set; }
        public ClientEntity client { get; set; }
        public RealtorEntity realtor { get; set; }
        public RealtyTypeEntity realty_type { get; set; }
    }
}
