using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airport.Infrastructure.Models
{
    public class AirplaneModel
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }

        public ICollection<FlightModel> Flights { get; set; }
    }
}