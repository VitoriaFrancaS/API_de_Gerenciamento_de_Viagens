using Journey.Application.UseCases.Viagens.Activities.Complete;
using Journey.Application.UseCases.Viagens.Activities.Delete;
using Journey.Application.UseCases.Viagens.Activities.Register;
using Journey.Application.UseCases.Viagens.Delete;
using Journey.Application.UseCases.Viagens.GetById;
using Journey.Application.UseCases.Viagens.ListarTodos;
using Journey.Application.UseCases.Viagens.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        [HttpPost]
        //Definindo os status code que cada método
        [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestRegisterTripJson request)
        {
            var useCase = new RegisterTripUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
        public IActionResult ListarTodos()
        {
            var useCase = new ListarTodasAsViagens();

            var result = useCase.Execute();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var useCase = new GetViagemById();

            var response = useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteTrip([FromRoute] Guid id)
        {
            var useCase = new DeleteTrip();

            useCase.Execute(id);

            return NoContent();
        }

        [HttpPost]
        [Route("{tripId}/activity")]
        [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult RegisterActivity([FromRoute] Guid tripId, [FromBody] RequestRegisterActivityJson request)
        {
            var useCase = new RegisterActivity();

            var response = useCase.Execute(tripId, request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{tripId}/activity/{activityId}/complete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult CompleteActivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
        {
            var useCase = new CompleteActivityForTrip();

             useCase.Execute(tripId, activityId);

            return NoContent();
        }

        [HttpDelete]
        [Route("{tripId}/activity/{activityId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult deleteActitivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
        {
            var useCase = new DeleteActivity();

            useCase.Execute(tripId, activityId);

            return NoContent(); 
        }






    }
}
