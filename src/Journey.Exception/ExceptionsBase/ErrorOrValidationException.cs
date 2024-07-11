using System.Net;

namespace Journey.Exception.ExceptionsBase;

public class ErrorOrValidationException : JourneyException
{
    private readonly IList<string> _errors;

    public ErrorOrValidationException(IList<string> message) : base(string.Empty)
    {
        _errors = message;
    }

    public override IList<string> GetErrorMessages()
    {
        return _errors;
    }

    public override HttpStatusCode GetStatusCode()
    {
       return HttpStatusCode.BadRequest;
    }
}
