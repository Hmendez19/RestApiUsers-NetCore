using System.Text.RegularExpressions;
using RestApiUsers.Common.Validators.Value;
using RestApiUsers.Modules.Users.Domain.Exceptions;

namespace RestApiUsers.Modules.Users.Domain.ValuesObject;

public class Email:ValueValidator
{
    private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    
    private readonly string _value;

    public Email(string value)
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
        EnsureValueNotInvalidFormat(value);
    }

    private void EnsureValueNotEmpty(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmailNotValidException("Email no puede ser vacío");
        }
    }

    private void EnsureValueNotInvalidFormat(string value)
    {
        Regex regex= new Regex(EmailPattern);
        if (!regex.IsMatch(value))
        {
            throw new EmailNotValidException("Email no tiene el formato correcto");
        }
    }

    private void EnsureValueNotToExceedCharacterLength(string value)
    {
        const int maxLength = 150;
        
        if (value.Length > maxLength)
        {
            throw new EmailNotValidException($"Email no puede tener más de {maxLength} caracteres");
        }
    }
}