namespace Services.MapperConfiguration
{
    using AutoMapper;
    using Domain.Dtos;
    using Domain.Entities;

    public class RegisterPersonProfile : Profile
    {
        public RegisterPersonProfile()
        {
            CreateMap<RegisterPersonCommand, People>(MemberList.Source)
                .ForMember(d => d.ModifiedOn, cfg => cfg.MapFrom(e => DateTime.Now))
                .ForMember(t => t.PersonId, s => s.Ignore())
                .ForMember(x => x.Addresses, opt => opt.MapFrom(s => s.Addresses.Select(address => new Address
                {
                    Description = address
                })))
                .ForMember(x => x.Emails, opt => opt.MapFrom(s => s.Emails.Select(email => new Email
                {
                    EmailAddress = email
                })))
                .ForMember(x => x.PhoneNumbers, opt => opt.MapFrom(s => s.PhoneNumbers.Select(phone => new Phone
                {
                    PhoneNumber = phone
                })));

            CreateMap<People, PeopleResponseDto>(MemberList.Source)
                .ForMember(x => x.Emails, opt => opt.MapFrom(s => s.Emails.Select(address => address.EmailAddress)))
                .ForMember(x => x.Addresses, opt => opt.MapFrom(s => s.Addresses.Select(address => address.Description)))
                .ForMember(x => x.PhoneNumbers, opt => opt.MapFrom(s => s.PhoneNumbers.Select(address => address.PhoneNumber)));

        }
    }
}
