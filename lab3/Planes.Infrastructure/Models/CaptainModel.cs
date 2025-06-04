using System;
using System.ComponentModel.DataAnnotations;

namespace Warships.Infrastructure.Models
{
    public class CaptainModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public WarshipModel? Warship { get; set; }
    }
}