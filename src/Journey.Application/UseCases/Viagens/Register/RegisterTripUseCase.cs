//Classe responsavel por ser a regra de negocio onde valida a request e persiste no bd
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Viagens.Register;

public class RegisterTripUseCase
{       //executando um caso de uso, nesse caso a criação de uma viagem
    public ResponseShortTripJson Execute(RequestRegisterTripJson request)
    {
        Validate(request);

        var dbContext = new JourneyDbContext();

        var entity = new Trip
        {
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
        };

        dbContext.Trips.Add(entity);

        dbContext.SaveChanges();

        return new ResponseShortTripJson
        {
            EndDate = entity.EndDate,
            StartDate = entity.StartDate,
            Name = entity.Name,
            Id = entity.Id
        };
    }

    //Criando a validação da resquest
    private void Validate(RequestRegisterTripJson request)
    {
       var validator = new RegisterTripValidator();

       var resultado = validator.Validate(request);

         if(resultado.IsValid == false)
        {
           var errorMessages =  resultado.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOrValidationException(errorMessages);
        }

    }
}
