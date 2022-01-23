using FluentValidation;

namespace MovieStoreWebApi.Application.OrderOperation.Command.UpdateOrderCommand
{
    public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(Oc=>Oc.Id).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(Oc=>Oc.updatedData.MovieId).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
            RuleFor(Oc=>Oc.updatedData.CustomerId).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
            RuleFor(Oc=>Oc.updatedData.TotalPrice).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}