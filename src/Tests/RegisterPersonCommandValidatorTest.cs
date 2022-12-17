namespace Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoFixture;
    using Domain.Dtos;
    using Domain.Entities;
    using FluentValidation.TestHelper;
    using NSubstitute;
    using Services.Validators.CommandValidators;
    using Services.Validators.Shared;
    using Xunit;

    public class RegisterPersonCommandValidatorTest
    {
        public static readonly Fixture _fixture = new();
        private readonly RegisterPersonCommandValidator _registerPersonCommandValidator;
        private readonly ICommonValidators _commonValidator;
        public RegisterPersonCommandValidatorTest()
        {
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _commonValidator = Substitute.For<ICommonValidators>();
            _registerPersonCommandValidator = new RegisterPersonCommandValidator(_commonValidator);
        }

        [Fact]
        public async Task RegisterPersonCommandValidator_When_DocumentId_is_in_DB()
        {
            // Arrange
            var fixture = _fixture.Build<People>()
                    .With(p => p.DocumentId, 1)
                    .Without(p => p.Addresses)
                    .Without(p => p.Emails)
                    .Without(p => p.PhoneNumbers)
                    .Create();
            _commonValidator.ConfigureTestData(new List<People> { fixture });

            var _request = new RegisterPersonCommand
            {
                DocumentId = 1
            };

            // Act
            var result = await _registerPersonCommandValidator.TestValidateAsync(_request);

            // Assert
            result.ShouldHaveValidationErrorFor(r => r.DocumentId);
        }

    }
}
