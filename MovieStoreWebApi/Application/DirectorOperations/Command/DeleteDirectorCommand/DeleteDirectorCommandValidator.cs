using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.DeleteDirectorCommand
{
    public class DeleteDirectorCommandValidator:AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(Dc=>Dc.Id).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}