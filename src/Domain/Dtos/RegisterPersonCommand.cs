namespace Domain.Dtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterPersonCommand : CommandBase<BaseResponse<bool>>
    {
        public int DocumentId { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public List<int>? PhoneNumbers { get; set; }
        public List<string>? Emails { get; set; }
        public List<string>? Addresses { get; set; }
    }
}
