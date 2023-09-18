using AccessControlServer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace AccessControlServer.Repositories
{
    public interface IEventsRepository
    {
        List<Events> GetEvents();
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

        public List<Events> GetEvents()
        {
            var events = new List<Events>();
            using (SqlConnection con = new SqlConnection(m_getDbConnection().ConnectionString))
            using (SqlCommand cmd = new SqlCommand("spGetEvents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    events.Add(new Events() { 
                        Message = reader[AccessControlConstants.Message].ToString() ?? "", 
                        Details = reader[AccessControlConstants.Details].ToString() ?? "", 
                        ArrivalTime = (DateTime)reader[AccessControlConstants.ArrivalTime] 
                    });
                }
            }
            return events;
        }
    }
}
