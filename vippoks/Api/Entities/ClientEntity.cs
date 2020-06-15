namespace vippoks.Api.Entities
{
    public class ClientEntity
    {
        public int id { get; set; }
        public string name {get; set;}
        public string surname { get; set;}
        public string patronymic { get; set;}
        public string phone { get; set;}
        public string email { get; set; }

        public string GetInitials { 
            get
            {
                return surname + " " + name.Substring(0,1) + "."+ patronymic.Substring(0,1) + ".";
            }
        }
    }
}
