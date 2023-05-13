using FluentValidation;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Create;

public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.Email)
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must have a valid email format");

        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}