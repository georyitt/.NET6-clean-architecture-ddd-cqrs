using FluentValidation;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector;

public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
{
    public CreateDirectorCommandValidator()
    {
        RuleFor(p => p.Nombre)
            .NotEmpty();
        
        RuleFor(p => p.Apellido)
            .NotEmpty();
    }
}