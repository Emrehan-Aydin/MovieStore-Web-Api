using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.UpdateDirectorCommand
{
    public class UpdateDirectorCommandValidator:AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(Dc=>Dc.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(Dc=>Dc.updatedModel.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(Dc=>Dc.updatedModel.Surname).NotNull().NotEmpty().MinimumLength(2).MaximumLength(20);
        }
    }
}