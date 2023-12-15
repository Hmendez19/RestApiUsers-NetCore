using Microsoft.AspNetCore.Mvc;

namespace RestApiUsers.Common.Exceptions.Handler;

public static class CustomHandleException
{
    public static Task<IActionResult> Handle(Exception ex,int _statusCode)
    {
        var statusCode = GetStatusCodeForException(_statusCode);
        return Task.FromResult(statusCode(ex.Message));
    }

    private static Func<string, IActionResult> GetStatusCodeForException(int _statusCode)
    {
        return StatusCode;

        IActionResult StatusCode(string message)
        {
            return new ObjectResult(new
            {
                error_message = message
            }) { StatusCode = _statusCode };
        }
    }
}