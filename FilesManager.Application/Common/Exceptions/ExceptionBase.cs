using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Application.Common.Exceptions;
public abstract class ExceptionBase : Exception
{
    public ExceptionBase(
        string message,
        IReadOnlyDictionary<string, string[]>? errors = null) : base(message)
    {
        Errors = errors;
    }

    public int StatusCode { get; set; }
    public string? Title { get; set; }
    public IReadOnlyDictionary<string, string[]>? Errors { get; set; }
}