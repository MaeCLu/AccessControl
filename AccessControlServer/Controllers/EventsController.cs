using AccessControlServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlServer.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class EventsController : Controller
{
    private ILogger<EventsController> m_logger;
    private IEventsService m_service;

    public EventsController(ILogger<EventsController> logger, IEventsService service)
    {
        m_logger = logger;
        m_service = service;
    }

    [HttpGet("events", Name = "GetEvents")]
    [Produces("application/json")]
    public ActionResult GetEvents()
    {
        return Ok(m_service.GetEvents());
    }

    [HttpGet("eventsPerMonthCurrentYear", Name = "GetEventsPerMonthForAYear")]
    [Produces("application/json")]
    public ActionResult GetEventsPerMonthForAYear()
    {
        return Ok(m_service.GetEventsPerMonthForAYear());
    }

    [HttpPost("GenerateAccessGranted", Name = "GenerateAccessGranted")]
    [AllowAnonymous]
    public async Task<ActionResult> GrantAccess([FromBody] EventModel e)
    {
        m_service.GenerateAccessGranted(e);
        return Ok();

    }
}
