namespace Journey.Communication.Responses;

public class ResponseErrorsJson
{
    //[] = a lista iniciará vazia
    public IList<string> Errors { get; set; } = [];

    public ResponseErrorsJson(IList<string> errors)
    {
        
        Errors = errors;
    }
}
