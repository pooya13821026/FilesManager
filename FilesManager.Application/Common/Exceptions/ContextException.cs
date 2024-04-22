using Microsoft.AspNetCore.Http;

namespace FilesManager.Application.Common.Exceptions;
public class ContextException : ExceptionBase
{
    public ContextException(string entityName, Exception exception) :
        base($"entity : {entityName} - exception message : {exception.Message}")
    {
        StatusCode = StatusCodes.Status500InternalServerError;
        Title = nameof(ContextException);
    }
}
