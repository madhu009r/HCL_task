using FluentValidation;
using StudentService.DTO;

public class CreateStudentDtoValidator : AbstractValidator<CreateStudent>
{
    public CreateStudentDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Today)
            .WithMessage("Date of birth must be in the past.");

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0);
    }
}
