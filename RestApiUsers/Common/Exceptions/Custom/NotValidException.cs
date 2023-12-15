namespace RestApiUsers.Common.Exceptions.Custom;

public  class NotValidException(string message) : Exception(message);