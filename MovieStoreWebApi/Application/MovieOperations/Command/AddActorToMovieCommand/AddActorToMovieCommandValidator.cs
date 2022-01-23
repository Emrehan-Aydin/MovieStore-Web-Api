using FluentValidation;

namespace MovieStoreWebApi.Application.MovieOperation.Command.AddActorToMovie
{   
    public class AddActorToMovieCommandValidator:AbstractValidator<AddActorToMovieCommand>
    {
        public AddActorToMovieCommandValidator()
        {
            RuleFor(Mc=>Mc.newMoviesActor.ActorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(Mc=>Mc.newMoviesActor.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
    
}