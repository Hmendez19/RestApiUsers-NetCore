using RestApiUsers.Modules.Users.Domain.Dto;

namespace RestApiUsers.Modules.Users.Domain.ValuesObject;

public class User
{
    private readonly FirstName _fistName;
    private readonly LastName _lastName;
    private readonly Email _email;
    private readonly Country _country;
    
    public User(UserDto currentUser)
    {
        _fistName = new FirstName(currentUser.FirstName);
        _lastName = new LastName(currentUser.LastName);
        _email = new Email(currentUser.Email);
        _country = new Country(currentUser.Country);
    }

    public string GetFistName()
    {
        return _fistName.Value();
    }

    public string GetLastName()
    {
        return _lastName.Value();
    }

    public string GetEmail()
    {
        return _email.Value();
    }

    public string GetCountry()
    {
        return _country.Value();
    }

    public string GetFullName()
    {
        return $"{_fistName.Value()} {_lastName.Value()}";
    }

    public override string ToString()
    {
        return $"{_fistName.Value()} {_lastName.Value()} {_email.Value()} {_country.Value()}";
    }
    
    public UserDto ToUserDto()
    {
        return new UserDto
        {
            FirstName = _fistName.Value(),
            LastName = _lastName.Value(),
            Email = _email.Value(),
            Country = _country.Value()
        };
    }
    
}