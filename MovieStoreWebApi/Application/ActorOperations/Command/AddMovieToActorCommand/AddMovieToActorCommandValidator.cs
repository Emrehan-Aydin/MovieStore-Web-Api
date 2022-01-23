using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Command.AddMovieToActorCommand
{
    public class AddMovieToActorCommandValidator:AbstractValidator<AddMovieToActorCommand>
    {
        public AddMovieToActorCommandValidator()
        {
            RuleFor(Ma=>Ma.newMoviesActorModel.ActorId).NotNull().GreaterThan(0);
            RuleFor(Ma=>Ma.newMoviesActorModel.MovieId).NotNull().GreaterThan(0);
        }
    }
}