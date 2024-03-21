using AccessControlServer.Models;
using AccessControlServer.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace AccessControlServer;

public interface IEventsService
{
    List<Event> GetEvents();
    List<EventsPerYear> GetEventsPerMonthForAYear();
    void GenerateAccessGranted(EventModel evt);
}
public class EventsService : IEventsService
{
    private IEventsRepository m_repository;

    public EventsService(IEventsRepository repository)
    {
        m_repository = repository;
    }

    public List<Event> GetEvents()
    {
        return m_repository.GetEvents();
    }

    public List<EventsPerYear> GetEventsPerMonthForAYear()
    {
        return m_repository.GetEventsPerMonthForAYear();
    }

    public void GenerateAccessGranted(EventModel evt)
    {
        m_repository.PostEvent(evt);
    }

    

}
