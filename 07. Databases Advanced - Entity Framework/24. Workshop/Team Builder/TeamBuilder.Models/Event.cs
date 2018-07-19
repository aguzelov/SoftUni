using System;
using System.Collections.Generic;

namespace TeamBuilder.Models
{
    public class Event
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                this._startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (value <= this.StartDate)
                    throw new ArgumentException("End date must be afret Start date!");

                this._endDate = value;
            }
        }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<TeamEvent> Teams { get; set; } = new List<TeamEvent>();
    }
}