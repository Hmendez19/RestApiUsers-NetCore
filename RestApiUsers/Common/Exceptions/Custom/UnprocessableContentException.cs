namespace RestApiUsers.Common.Exceptions.Custom;

public class UnprocessableContentException(string message) : Exception(message);