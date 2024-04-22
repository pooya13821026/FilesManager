using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace FilesManager.Application.Common.Exceptions;
public class ApplicationValidationException : ExceptionBase
{
    public ApplicationValidationException() :
        base("One or more validation failures occurred!")
    {
        StatusCode = StatusCodes.Status400BadRequest;
        Title = nameof(ApplicationValidationException);
    }

    public ApplicationValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        StatusCode = StatusCodes.Status400BadRequest;
        Title = nameof(ApplicationValidationException);

        Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(d => d.Key, d => d.ToArray());
    }
}
