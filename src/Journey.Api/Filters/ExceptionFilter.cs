//Filtro de exceção, toda as exceções do projeto serão capturadas por aqui e capturamos aqui devolvendo com o status code correto 

using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
       if (context.Exception is JourneyException)
       {
            var journey = (JourneyException)context.Exception;

            //(int) = o GetStatusCode é enum com o int estou convertendo ele para um int
            context.HttpContext.Response.StatusCode = (int)journey.GetStatusCode();
            var responseJson = new ResponseErrorsJson(journey.GetErrorMessages());
            context.Result =new ObjectResult(responseJson);
       }
      
       else
       {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var responseJson = new ResponseErrorsJson(new List<string> { ResourceErrorMessages.ERRO_DESCONHECIDO});
            context.Result = new ObjectResult(responseJson);
       }
    }
}
