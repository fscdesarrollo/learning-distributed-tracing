using System;

namespace Learning.DistributedTracing.Wars.Api
{
    public class WarModel
    {
        public WarModel()
        {

        }

        public WarModel(Guid warId, string message, DateTime date)
        {
            WarId = warId;
            Message = message;
            Date = date;
        }
        public Guid WarId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
