using CleanArchitecture.Application.CQRS.Courses.Commands.Register;
using FluentValidation;

namespace CleanArchitecture.Application.Validators
{
    public class RegisterCourseValidator : AbstractValidator<RegisterCourseCommand>
    {
        public RegisterCourseValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("O campo Nome não pode ser vazio!")
                .MinimumLength(3)
                .WithMessage("O campo Nome tem que ter no mínimo 3 caracteres");
        }
    }
}
