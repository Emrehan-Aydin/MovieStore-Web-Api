using FluentValidation;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.UpdateCustomerCommand
{
    public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(Cc=>Cc.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(Cc=>Cc.updatedData.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);;
            RuleFor(Cc=>Cc.updatedData.Surname).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);;
        }
    }
}