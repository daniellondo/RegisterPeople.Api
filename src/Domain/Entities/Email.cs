namespace Domain.Entities
{
    public class Email
    {
        public Email() => ModifiedOn = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
        public int EmailId { get; set; }
        public string EmailAddress { get; set; }
        public int PersonId { get; set; }
        public People? People { get; set; }
    }
}
