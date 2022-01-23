using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.AddDirectorCommand
{
    public class CreateDirectorCommandValidator:AbstractValidator<CreateDirectorCommand>
    {   
        public CreateDirectorCommandValidator()
        {
            RuleFor(Dc=>Dc.createDirectorModel.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(Dc=>Dc.createDirectorModel.Surname).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20);
        }
        
    }
}