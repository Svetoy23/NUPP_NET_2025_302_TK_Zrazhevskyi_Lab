using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warships.Infrastructure.Models
{
    public class CrewMemberModel
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        public Guid WarshipModelId { get; set; }
        public WarshipModel Warship { get; set; } = null!;
    }
}