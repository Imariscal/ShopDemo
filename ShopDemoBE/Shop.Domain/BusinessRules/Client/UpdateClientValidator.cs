using FluentValidation; 
using Shop.Domain.DTOs.Client;
 

namespace Shop.Domain.BusinessRules.Client
{
    public class UpdateClientValidator : AbstractValidator<ClientDTO>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Client name is requerid").MinimumLength(3).WithMessage("Client name cant be less then 3 characters");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adrress is requerid");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is requerid").MinimumLength(3).WithMessage("Last name cant be less then 3 characters");
        }
    }
}
