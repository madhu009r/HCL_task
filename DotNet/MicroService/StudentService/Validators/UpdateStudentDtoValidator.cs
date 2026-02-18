using FluentValidation;
using StudentService.DTO;

namespace StudentService.Validators
{
    

    public class UpdateStudentDtoValidator : AbstractValidator<UpdateStudent>
    {
        public UpdateStudentDtoValidator()
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
                .LessThan(DateTime.Today);

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0);
        }
    }

}
