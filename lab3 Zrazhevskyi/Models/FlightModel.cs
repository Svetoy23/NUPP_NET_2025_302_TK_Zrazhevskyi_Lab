using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Infrastructure.Models
{
    public class FlightModel
    {
        [Key]
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }

        public int AirplaneId { get; set; }
        public AirplaneModel Airplane { get; set; }
    }
}