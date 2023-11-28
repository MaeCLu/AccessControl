using AccessControlServer.Models;
using AccessControlServer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AccessControlServer.Test
{
    [TestClass]
    public class EventService
    {
        [TestMethod]
        public void GetEvents()
        {
            var mockRepository = new Mock<IEventsRepository>();
            var events = new List<Events>();
            var etype = new EventType() { Name = "Event Type 1" };
            events.Add(new Events { EventType = etype.Name , ArrivalTime = DateTime.Now, Details = "unit test details", Message = "My unittest message" });
            mockRepository.Setup(r => r.GetEvents()).Returns(events);
            var eventService = new EventsService(mockRepository.Object);

            Assert.AreEqual(events, eventService.GetEvents());
        }
    }
}