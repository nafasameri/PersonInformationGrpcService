using FluentValidation;
using PersonInformationGrpcService.Presentation;

namespace PersonInformationGrpcService.Application.Validators
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MaximumLength(50)
                .WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MaximumLength(50)
                .WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.NationalCode)
                .NotEmpty()
                .WithMessage("National code is required.")
                .Length(10)
                .WithMessage("National code must be exactly 10 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required.")
                .Must(BeAValidDate)
                .WithMessage("Date of birth must be a valid date.");
        }

        private bool BeAValidDate(string date)
        {
            return DateTime.TryParse(date, out _);
        }
    }
}
