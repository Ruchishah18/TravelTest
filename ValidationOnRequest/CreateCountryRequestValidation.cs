using FluentValidation;
using IntuitiveTest.Requests;

namespace IntuitiveTest.ValidationOnRequest
{
    public class CreateCountryRequestValidation : AbstractValidator<CreateCountryRequest>
    {
        public CreateCountryRequestValidation()
        {
            RuleFor(p=>p.Name).NotEmpty();
        }
    }
}
