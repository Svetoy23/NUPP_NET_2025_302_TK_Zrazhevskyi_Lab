using System;

namespace Airport.REST.Models
{
    public class FlightModel
    {
        public Guid Id { get; set; }
        public int FlightNumber { get; set; }
        public string AirplaneName { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal TicketCost { get; set; }
    }
}
