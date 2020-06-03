namespace vippoks.Api.Entities
{
    class OfferEntity
    {
        public int id { get; set; }
        public int price { get; set; }
        public ClientEntity client { get; set; } 
        public RealtorEntity realtor { get; set; }
        public RealtyTypeEntity realty_type { get; set; }

    }
}
