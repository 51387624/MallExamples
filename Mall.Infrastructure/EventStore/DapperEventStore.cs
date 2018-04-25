using Dapper;
using Mall.Core.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Mall.Infrastructure.EventStore
{
    public class DapperEventStore : IEventStore
    {
        private readonly string connectionString;

        public DapperEventStore(string connectionString, ILogger<DapperEventStore> loggerFactory)
        {
            this.connectionString = connectionString;
        }

       
        public async Task SaveEventAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            const string sql = @"INSERT INTO [dbo].[Events] ([EventId], [EventTimestamp], [EventPayload]) VALUES (@eventId, @eventPayload, @eventTimestamp)";
            using (var connection = new SqlConnection(this.connectionString))
            {
                await connection.ExecuteAsync(sql, new
                {
                    eventId = @event.Id,
                    eventPayload = JsonConvert.SerializeObject(@event),
                    eventTimestamp = @event.Timestamp
                });
            }
        }

        public void Dispose()
        {
        }
    }
}
