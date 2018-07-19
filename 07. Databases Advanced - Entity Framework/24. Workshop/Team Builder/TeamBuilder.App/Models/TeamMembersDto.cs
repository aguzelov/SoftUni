using System.Collections.Generic;
using TeamBuilder.Models;

namespace TeamBuilder.App.Models
{
    public class TeamMembersDto
    {
        public string Name { get; set; }

        public string Acronym { get; set; }

        public ICollection<UserTeam> Users { get; set; }
    }
}