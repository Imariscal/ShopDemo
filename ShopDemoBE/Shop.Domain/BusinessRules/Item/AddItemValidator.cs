using FluentValidation;  
using Shop.Domain.DTOs.Item;

namespace Shop.Domain.BusinessRules.Item
{
    public class AddItemValidator : AbstractValidator<ItemDTO>
    {
        public AddItemValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Item Code  is required").MinimumLength(3).WithMessage("Item Code name cant be less then 3 characters");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descripcion is required");
            RuleFor(x => x.Prize).GreaterThan(0).WithMessage("Prize should be greater then 0");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock number should be greater then or equal to 0");
        }
    }

}
