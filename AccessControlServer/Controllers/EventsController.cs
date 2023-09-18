﻿using Microsoft.AspNetCore.Authorization;
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
}
