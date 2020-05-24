using System;

namespace Learning.DistributedTracing.Star.Api.Model
{
    public class StarModel
    {
        public StarModel()
        {

        }

        public StarModel(Guid starId, string message, DateTime date)
        {
            StarId = starId;
            Message = message;
            Date = date;
        }

        public Guid StarId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
