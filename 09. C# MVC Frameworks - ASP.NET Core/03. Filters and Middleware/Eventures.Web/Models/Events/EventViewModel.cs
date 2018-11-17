using System;

namespace Eventures.Web.Models.Events
{
    public class EventViewModel
    {
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Place { get; set; }
    }
}