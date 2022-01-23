using FluentValidation;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.AddCustomerCommand
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(Cc=>Cc.createCustomerModel.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);;
            RuleFor(Cc=>Cc.createCustomerModel.Surname).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);;
        }
    }
}