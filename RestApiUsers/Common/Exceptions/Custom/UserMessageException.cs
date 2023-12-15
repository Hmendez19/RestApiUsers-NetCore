namespace RestApiUsers.Common.Exceptions.Custom;

public class UserMessageException(string message) : NotValidException(message);