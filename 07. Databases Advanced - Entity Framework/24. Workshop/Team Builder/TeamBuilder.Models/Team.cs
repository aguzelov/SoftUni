using System.Collections.Generic;

namespace TeamBuilder.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<Invitation> SendedInvitations { get; set; } = new List<Invitation>();
        public ICollection<UserTeam> Users { get; set; } = new List<UserTeam>();
        public ICollection<TeamEvent> Events { get; set; } = new List<TeamEvent>();
    }
}