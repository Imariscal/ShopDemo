namespace Shop.Domain.BusinessRules.Base;

public interface IValidationStrategy<T>
{
    ValidationResult Validate(T instance);
}
