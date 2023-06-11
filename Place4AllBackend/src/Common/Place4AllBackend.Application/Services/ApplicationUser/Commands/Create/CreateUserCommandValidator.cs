using FluentValidation;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.Email)
            .MaximumLength(100).WithMessage("El email no debe ser superior a 100 caracteres.")
            .NotEmpty().WithMessage("El email es obligatorio.")
            .EmailAddress().WithMessage("El email debe tener un formato válido");

        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("La contraseña es obligatoria.");
    }
}