using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperation.Command.DeleteGenreCommand
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(Gc=>Gc.Id);
        }
    }
}