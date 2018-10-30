using System;
using System.Collections.Generic;
using System.Linq;

namespace Torshia.App.ViewModels
{
    public class CreateTaskView
    {
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string ParticipantsAsString { get; set; }

        public string CustomersCheckbox { get; set; }
        public string MarketingCheckbox { get; set; }
        public string FinancesCheckbox { get; set; }
        public string InternalCheckbox { get; set; }
        public string ManagementCheckbox { get; set; }

        public ICollection<string> Sectors()
        {
            var sectors = new List<string>();

            var checkboxs = this.GetType().GetProperties()
                .Where(p => p.Name.Contains("Checkbox"))
                .ToList();

            foreach (var checkbox in checkboxs)
            {
                var value = checkbox.GetValue(this);

                if (value != null)
                {
                    sectors.Add(value.ToString());
                }
            }

            return sectors;
        }

        public ICollection<string> Participants()
        {
            return this.ParticipantsAsString.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}