using FluentValidation;

namespace  MovieStoreWebApi.Application.MovieOperation.Command.AddMovieCommand
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(Mc=>Mc.createMovieModel.Name).NotNull().MaximumLength(30).MinimumLength(1);
            RuleFor(Mc=>Mc.createMovieModel.Price).NotNull().GreaterThan(0);
            RuleFor(Mc=>Mc.createMovieModel.MovieYear).NotNull().GreaterThan(1900);
            RuleFor(Mc=>Mc.createMovieModel.GenreId).NotNull().GreaterThan(0);
            RuleFor(Mc=>Mc.createMovieModel.DirectorId).NotNull().GreaterThan(0);        
        }
    }
}