namespace ProductManagementApp.Validation;

public class ValidationResult
{
    private readonly List<string> _errors = [];

    public IReadOnlyList<string> Errors => _errors;
    public bool IsValid => _errors.Count == 0;

    public void AddError(string errorMessage)
    {
        _errors.Add(errorMessage);
    }
}
