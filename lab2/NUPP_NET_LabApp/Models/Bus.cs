using System;

namespace NUPP_NET_LabApp.Models
{
    public class Bus
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Capacity { get; set; }
        public string Model { get; set; }

        public static Bus CreateNew()
        {
            var random = new Random();
            return new Bus
            {
                Capacity = random.Next(20, 100),
                Model = "Model_" + Guid.NewGuid().ToString("N").Substring(0, 5)
            };
        }
    }
}
