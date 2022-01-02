namespace MicroVideosCatalog.Domain.Common;

public abstract record FluentValidator<T> where T : class
{
    private static MethodInfo _validatorMethodInfo = typeof(FluentValidator<T>).GetMethod(nameof(ConfigureValidations), BindingFlags.Instance | BindingFlags.NonPublic);
    private Validator _validator { get; init; }
    private ValidationResult _validationResult { get; set; }
    protected FluentValidator()
    {
        _validator = new();
        _validatorMethodInfo?.Invoke(this, new object[] { _validator });
    }
    protected abstract void ConfigureValidations(Validator ruler);
    public bool IsValid()
    {
        var descriptor = _validator.CreateDescriptor();
        if (descriptor.Rules.Any() is false)
            return false;
        _validationResult = _validator.Validate((T)ChangeType(this, typeof(T)));
        return _validationResult.IsValid;
    }
    public IEnumerable<ValidationFailure> GetValidationErros() => _validationResult.Errors;
    protected sealed class Validator : AbstractValidator<T> { }
}