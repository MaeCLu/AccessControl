using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlServer.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class EventsController : Controller
{
    private ILogger<EventsController> m_logger;

    public EventsController(ILogger<EventsController> logger)
    {
        m_logger = logger;
    }

    [HttpGet("events", Name = "GetEvents")]
    [Produces("application/json")]
    public ActionResult GetEvents()
    {
       // var settings = m_configService.GetBasicDiagnosticSettings();
        // Since this endpoint is unauthenticated - to avoid information disclosure, only return public settings.
        return Ok();
    }
}
