using RestApiUsers.Common.Exceptions.Custom;
using RestApiUsers.Common.Validators.Value;
using RestApiUsers.Modules.Users.Domain.Exceptions;

namespace RestApiUsers.Modules.Users.Domain.ValuesObject;

public class Country:ValueValidator
{
    private readonly string _value;
    public Country(string value)
    {
        _value = value;
        EnsureValueIsValid(value);
    }

    public string Value()
    {
        return _value;
    }

    protected sealed override void EnsureValueIsValid(string value)
    {
        EnsureValueNotEmpty(value);
        EnsureValueNotToExceedCharacterLength(value);
    }
    
    private void EnsureValueNotEmpty(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new CountryNotValidException("Country no puede ser vacío");
        }
    }
    
    private void EnsureValueNotToExceedCharacterLength(string value)
    {
        const int maxLength = 100;
        
        if (value.Length > maxLength)
        {
            throw new UnprocessableContentException($"Country no puede tener más de {maxLength} caracteres");
        }
    }
}