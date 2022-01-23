using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Command.AddActorCommand
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {       
        public CreateActorCommandValidator()
        {
            RuleFor(c=>c.Model.Name).MinimumLength(4).NotNull();
            RuleFor(c=>c.Model.Surname).MinimumLength(2).NotNull();
        }
    }
}