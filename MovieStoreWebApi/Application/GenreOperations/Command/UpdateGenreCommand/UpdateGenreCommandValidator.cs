using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperation.Command.UpdateGenreCommand
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(Gc=>Gc.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(Gc=>Gc.updatedData.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
        }
    }
}