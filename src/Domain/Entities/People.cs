namespace Domain.Entities
{
    using System;
    public class People
    {
        public People() => ModifiedOn = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
        public int PersonId { get; set; }
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public List<Phone> PhoneNumbers { get; set; }
        public List<Email> Emails { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
