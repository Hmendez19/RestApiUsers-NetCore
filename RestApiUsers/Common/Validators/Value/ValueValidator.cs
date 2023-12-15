namespace RestApiUsers.Common.Validators.Value;

public abstract class ValueValidator
{
    protected abstract void EnsureValueIsValid(string value);
}