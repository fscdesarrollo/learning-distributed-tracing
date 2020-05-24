using System;

namespace Learning.DistributedTracing.Star.Api.Clients.War
{
    public class WarsResponse
    {
        public Guid WarId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
