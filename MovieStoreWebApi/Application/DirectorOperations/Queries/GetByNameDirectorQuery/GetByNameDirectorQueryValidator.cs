using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperation.Queries.GetByNameDirectorQuery
{
    public class GetByNameDirectorQueryValidator:AbstractValidator<GetByNameDirectorQuery>
    {
        public GetByNameDirectorQueryValidator()
        {
            RuleFor(Dq=>Dq.name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(Dq=>Dq.surname).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20);
        }
    }
}