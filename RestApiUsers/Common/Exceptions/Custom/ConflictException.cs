namespace RestApiUsers.Common.Exceptions.Custom;

public class ConflictException(string message) : Exception(message);