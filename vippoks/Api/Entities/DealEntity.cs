using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vippoks.Api.Entities
{
    public class DealEntity
    {
        public int id { get; set; }
        public OfferEntity offers { get; set; }
        public NeedsEntity needs { get; set; }
    }
}
