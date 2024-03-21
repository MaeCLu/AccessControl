using AccessControlServer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace AccessControlServer.Repositories
{
    public interface IEventsRepository
    {
        List<Event> GetEvents();
        List<EventsPerYear> GetEventsPerMonthForAYear();
        bool PostEvent(EventModel evt);
    }
    public class EventsRepository : IEventsRepository
    {
        private IConfiguration m_configuration;
        private Func<IDbConnection> m_getDbConnection;
        private Func<IDbDataParameter> m_getDbDataParam;
        private readonly ILogger<EventsService> m_logger;

        public EventsRepository(IConfiguration config, ILogger<EventsService> logger, Func<IDbConnection> getDbConnection, Func<IDbDataParameter> getDbDataParam)
        {
            m_configuration = config;
            m_getDbConnection = getDbConnection;
            m_getDbDataParam = getDbDataParam;
            m_logger = logger;
        }

        public List<Event> GetEvents()
        {
            var events = new List<Event>();
            using (SqlConnection con = new SqlConnection(m_getDbConnection().ConnectionString))
            using (SqlCommand cmd = new SqlCommand("spGetEvents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    events.Add(new Event() {
                        Id = reader[AccessControlConstants.Id].ToString() ?? "0",
                        Severity = reader[AccessControlConstants.Severity].ToString() ?? "",
                        Message = reader[AccessControlConstants.Message].ToString() ?? "", 
                        Details = reader[AccessControlConstants.Details].ToString() ?? "", 
                        ArrivalTime = (DateTime)reader[AccessControlConstants.ArrivalTime] 
                    });
                }
            }
            return events;
        }

        public bool PostEvent(EventModel evt)
        {
            using (SqlConnection con = new SqlConnection(m_getDbConnection().ConnectionString))
            using (SqlCommand cmd = new SqlCommand("spPostEvents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SeverityId", SqlDbType.Int).Value = evt.SeverityId;
                cmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = evt.Message;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = evt.Details;

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public List<EventsPerYear> GetEventsPerMonthForAYear()
        {
            var eventsPerYear = new List<EventsPerYear>();
            using (SqlConnection con = new SqlConnection(m_getDbConnection().ConnectionString))
            using (SqlCommand cmd = new SqlCommand("spGetEventsPerMonthForAYear", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    eventsPerYear.Add(new EventsPerYear()
                    {
                        Year = reader[AccessControlConstants.Year].ToString() ?? "2024",
                        Month = reader[AccessControlConstants.Month].ToString() ?? "3",
                        Severity = reader[AccessControlConstants.Severity].ToString() ?? "",
                        Total = reader[AccessControlConstants.Total].ToString() ?? "0",
                    });
                }
            }
            return eventsPerYear;
        }
    }
}
