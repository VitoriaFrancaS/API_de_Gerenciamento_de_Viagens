using System.Net;

namespace Journey.Exception.ExceptionsBase;

public abstract class JourneyException:SystemException
{
    public JourneyException(string message):base(message)
    {
        
    }

    //*Definindo que toda classe que herdar do journey
    //vai chamar um get status code*//
    public abstract HttpStatusCode GetStatusCode();

    public abstract IList<string> GetErrorMessages();
}
