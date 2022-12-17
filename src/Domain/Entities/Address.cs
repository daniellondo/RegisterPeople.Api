namespace Domain.Entities
{
    public class Address
    {
        public Address() => ModifiedOn = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
        public int AddressId { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
        public People? People { get; set; }
    }
}
