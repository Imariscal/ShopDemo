using FluentValidation;  
using Shop.Domain.DTOs.ShopStore;

namespace Shop.Domain.BusinessRules.ShopStore
{
    public class AddShopStoreValidator : AbstractValidator<ShopStoreDTO>
    {
        public AddShopStoreValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Shop store name is requerid").MinimumLength(3).WithMessage("shop store name cant be less then 3 characters");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adrress is requerid");     
        }
    }
}
