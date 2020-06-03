using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vippoks.Api.Entities
{
    class OffersEntity
    {
        int id { get; set; }
        int price { get; set; }
        ClientEntity client { get; set; } 
        RealtorEntity realtor { get; set; }
        RealtyTypeEntity realty_type { get; set; }
    }
}
