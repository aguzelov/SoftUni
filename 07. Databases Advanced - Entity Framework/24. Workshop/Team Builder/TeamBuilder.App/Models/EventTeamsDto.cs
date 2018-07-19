using System;
using System.Collections.Generic;
using TeamBuilder.Models;

namespace TeamBuilder.App.Models
{
    public class EventTeamsDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public ICollection<TeamEvent> Teams { get; set; }
    }
}