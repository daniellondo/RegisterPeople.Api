namespace Domain.Entities
{
    public class Phone
    {
        public Phone() => ModifiedOn = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
        public int PhoneId { get; set; }
        public int PhoneNumber { get; set; }
        public int PersonId { get; set; }
        public People? People { get; set; }
    }
}
