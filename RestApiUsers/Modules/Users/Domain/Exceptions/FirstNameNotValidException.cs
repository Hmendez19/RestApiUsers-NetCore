using RestApiUsers.Common.Exceptions.Custom;

namespace RestApiUsers.Modules.Users.Domain.Exceptions;

public class FirstNameNotValidException(string message) : NotValidException(message);