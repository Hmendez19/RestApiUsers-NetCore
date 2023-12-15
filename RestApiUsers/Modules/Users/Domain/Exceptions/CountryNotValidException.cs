using RestApiUsers.Common.Exceptions.Custom;

namespace RestApiUsers.Modules.Users.Domain.Exceptions;

public class CountryNotValidException(string message) : NotValidException(message);