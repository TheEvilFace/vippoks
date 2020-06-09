namespace vippoks.Api.Entities
{
    public class OfferEntity
    {
        public int id { get; set; }
        public double price { get; set; }
        public ClientEntity client { get; set; }
        public RealtorEntity realtor { get; set; }
        public RealtyTypeEntity realty_type { get; set; }
        public string GetOffer
        {
            get
            {
                return client.GetInitials + " Цена:" + price;
            }
        }
    }
}
