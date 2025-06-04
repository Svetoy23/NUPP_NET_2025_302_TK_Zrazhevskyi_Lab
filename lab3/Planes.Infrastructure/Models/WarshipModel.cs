using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Warships.Infrastructure.Models
{
    public class WarshipModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public Guid CaptainId { get; set; }
        public CaptainModel Captain { get; set; } = null!;

        public List<CrewMemberModel> CrewMembers { get; set; } = new();
    }
}