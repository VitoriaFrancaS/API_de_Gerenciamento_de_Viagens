using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Viagens.GetById;

public class GetViagemById
{
    public ResponseTripJson Execute(Guid id)
    {
        var dbContext = new JourneyDbContext();

        var trip = dbContext
            .Trips
            .Include(trip => trip.Activities) //Definindo que você quer que faça o join com a tabela de atividades para trazer a informação completa 
            .FirstOrDefault(trip => trip.Id == id);

        if(trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.VIAGEM_NAO_ENCONTRADA);
        }

        return new ResponseTripJson
        {
            Id = trip.Id,
            Name = trip.Name,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            Activities = trip.Activities.Select(atividade => new ResponseActivityJson
            {
                Id = atividade.Id,
                Name = atividade.Name,
                Date = atividade.Date,
                Status = (Communication.Enums.ActivityStatus)atividade.Status,
            }).ToList()
        };
    }
}
