using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Command.UpdateActorCommand
{
    public class UpdateActorCommandValidator:AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(Upd =>Upd.Id).GreaterThan(0).NotNull();
            RuleFor(Upd=>Upd.updatedData.Name).MinimumLength(4).NotNull();
            RuleFor(Upd=>Upd.updatedData.Surname).MinimumLength(2).NotNull();
        }
    }
}