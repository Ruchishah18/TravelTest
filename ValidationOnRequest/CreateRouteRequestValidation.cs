using FluentValidation;
using IntuitiveTest.Requests;

namespace IntuitiveTest.ValidationOnRequest
{
    public class CreateRouteRequestValidation : AbstractValidator<CreateRouteRequest>
    {
        public CreateRouteRequestValidation()
        {
            RuleFor(p=> p.ArrivalAirportGroupId).NotEmpty().GreaterThan(0);
            RuleFor(p => p.DepartureAirportGroupId).NotEmpty().GreaterThan(0);
        }
    }
}
