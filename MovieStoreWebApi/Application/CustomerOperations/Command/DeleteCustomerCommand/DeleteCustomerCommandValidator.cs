using FluentValidation;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.DeleteCustomerCommand
{
    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(Cc=>Cc.Id).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}