using RestApiUsers.Common.Exceptions.Custom;

namespace RestApiUsers.Modules.Users.Domain.Exceptions;

public class LastNameNotValidException(string message) : NotValidException(message);