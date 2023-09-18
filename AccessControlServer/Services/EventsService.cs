using AccessControlServer.Models;
using AccessControlServer.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace AccessControlServer;

public interface IEventsService
{
    List<Events> GetEvents();
}
public class EventsService : IEventsService
{
    private IEventsRepository m_repository;

    public EventsService(IEventsRepository repository)
    {
        m_repository = repository;
    }

    public List<Events> GetEvents()
    {
        return m_repository.GetEvents();
    }
}
