using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Journey.Exception;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Viagens.Delete;

public class DeleteTrip
{
    public void Execute(Guid id)
    {
        var dbContext = new JourneyDbContext();

        var trip = dbContext
            .Trips
            .Include(trip => trip.Activities) //Definindo que você quer que faça o join com a tabela de atividades para trazer a informação completa 
            .FirstOrDefault(trip => trip.Id == id);

        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.VIAGEM_NAO_ENCONTRADA);
        }

        dbContext.Trips.Remove(trip);
        dbContext.SaveChanges();
    }
}

