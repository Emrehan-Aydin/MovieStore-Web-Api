using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Queries.GetByNameActorQuery
{
    public class GetByNameActorQueryValidator:AbstractValidator<GetByNameActorQuery>
    {
        public GetByNameActorQueryValidator()
        {
            RuleFor(Ga=>Ga.name).MinimumLength(3).NotNull();
            RuleFor(Ga=>Ga.surname).MinimumLength(3).NotNull();
        }
    }
}