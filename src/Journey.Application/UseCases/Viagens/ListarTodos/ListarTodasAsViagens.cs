using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Viagens.ListarTodos;

public class ListarTodasAsViagens
{
    public ResponseTripsJson Execute()
    {
        var dbContext = new JourneyDbContext();

        var Trips = dbContext.Trips.ToList();

        return new ResponseTripsJson
        {
            Trips = Trips.Select(trip => new ResponseShortTripJson
           {
               Id = trip.Id,
               Name = trip.Name,
               EndDate = trip.EndDate,
               StartDate = trip.StartDate,
           }).ToList()
        };
    }
}
