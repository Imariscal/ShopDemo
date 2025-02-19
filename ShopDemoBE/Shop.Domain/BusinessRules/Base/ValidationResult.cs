﻿
using Shop.CrossCutting.Validators.Contracts;

namespace Shop.Domain.BusinessRules.Base;

public class ValidationResult
{
    public bool IsValid { get; set; }
    public IList<IValidationFailure> Errors { get; set; } = [];
}

public class ValidationFailure(string propertyName, string errorMessage) : IValidationFailure
{
    public string PropertyName { get; set; } = propertyName;
    public string ErrorMessage { get; set; } = errorMessage;
}