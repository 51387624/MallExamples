using Mall.Core.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
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
            //const string sql = @"INSERT INTO [dbo].[Events] ([EventId], [EventPayload], [EventTimestamp]) VALUES (@eventId, @eventPayload, @eventTimestamp)";
            //using (var connection = new SqlConnection(this.connectionString))
            //{
            //    await connection.ExecuteAsync(sql, new
            //    {
            //        eventId = @event.Id,
            //        eventPayload = JsonConvert.SerializeObject(@event),
            //        eventTimestamp = @event.Timestamp
            //    });
            //}
        }

        public void Dispose()
        {
        }
    }
}
