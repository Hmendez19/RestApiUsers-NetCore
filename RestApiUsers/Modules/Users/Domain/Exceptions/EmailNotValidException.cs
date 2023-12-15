using RestApiUsers.Common.Exceptions.Custom;

namespace RestApiUsers.Modules.Users.Domain.Exceptions;

public class EmailNotValidException(string message) : NotValidException(message);