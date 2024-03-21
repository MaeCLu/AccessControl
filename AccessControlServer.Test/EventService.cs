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
            var events = new List<Event>();
            var etype = new Severity() { Name = "Severity 1" };
            events.Add(new Event { Severity = etype.Name , ArrivalTime = DateTime.Now, Details = "unit test details", Message = "My unittest message" });
            mockRepository.Setup(r => r.GetEvents()).Returns(events);
            var eventService = new EventsService(mockRepository.Object);

            Assert.AreEqual(events, eventService.GetEvents());
        }

        [TestMethod]
        public void PostEvents()
        {
            var mockRepository = new Mock<IEventsRepository>();
            var evt = new EventModel() { SeverityId = 1, Details = "unit test details", Message = "My unittest message" };
            mockRepository.Setup(r => r.PostEvent(evt)).Returns(true);
            var eventService = new EventsService(mockRepository.Object);
        }
    }
}