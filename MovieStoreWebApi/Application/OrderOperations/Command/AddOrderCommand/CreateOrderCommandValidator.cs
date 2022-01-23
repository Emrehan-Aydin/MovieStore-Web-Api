using FluentValidation;

namespace MovieStoreWebApi.Application.OrderOperation.Command.AddOrderCommand
{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(Oc=>Oc.createOrderModel.CustomerId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(Oc=>Oc.createOrderModel.MovieId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(Oc=>Oc.createOrderModel.TotalPrice).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}