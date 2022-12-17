namespace Services.Validators.CommandValidators
{
    using System;
    using System.Text.RegularExpressions;
    using Domain.Dtos;
    using Domain.Entities;
    using FluentValidation;
    using Services.Validators.Shared;

    public class RegisterPersonCommandValidator : AbstractValidator<RegisterPersonCommand>
    {
        public RegisterPersonCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(person => person.DocumentId)
                .NotEmpty()
                .Must(IsAlphanumeric)
                .WithMessage("Only alphanumeric characters are allowed.");

            RuleFor(person => person.Name).NotEmpty();
            RuleFor(person => person.FirstName).NotEmpty();
            RuleFor(person => person.LastName).NotEmpty();
            RuleFor(person => person.Birthday).NotEmpty();

            RuleFor(person => person.DocumentId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(documentId => !commonValidators.IsExistingEntityRowAsync<People>(u => u.DocumentId == documentId))
                .WithMessage("You cannot add 2 people with the same document id");

            RuleFor(m => m.Emails).NotNull().NotEmpty().When(m => (m.Addresses is null || !m.Addresses.Any()) && (m.PhoneNumbers is null || !m.PhoneNumbers.Any()));
            RuleFor(m => m.Addresses).NotNull().NotEmpty().When(m => (m.Emails is null || !m.Emails.Any()) && (m.PhoneNumbers is null || !m.PhoneNumbers.Any()));
            RuleFor(m => m.PhoneNumbers).NotNull().NotEmpty().When(m => (m.Addresses is null || !m.Addresses.Any()) && (m.Emails is null || !m.Emails.Any()));

            When(person => person.Addresses != null && person.Addresses.Any(), () =>
            {
                RuleFor(person => person.Addresses.Count).LessThanOrEqualTo(2);
            });

            When(person => person.Emails != null && person.Emails.Any(), () =>
            {
                RuleFor(person => person.Emails.Count).LessThanOrEqualTo(2);
            });

            When(person => person.PhoneNumbers != null && person.PhoneNumbers.Any(), () =>
            {
                RuleFor(person => person.PhoneNumbers.Count).LessThanOrEqualTo(2);
            });
        }

        private static bool IsAlphanumeric(int x)
        {
            var regex = new Regex(@"^[a-zA-Z0-9]+$");
            return regex.IsMatch(x.ToString());
        }
    }
}
