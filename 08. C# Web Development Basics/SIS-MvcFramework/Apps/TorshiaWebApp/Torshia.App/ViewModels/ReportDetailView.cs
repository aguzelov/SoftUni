namespace Torshia.App.ViewModels
{
    public class ReportDetailView
    {
        public int Id { get; set; }

        public string TaskTitle { get; set; }

        public string TaskLevel { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string ReportedOn { get; set; }
        public string Reporter { get; set; }
        public string TaskParticipants { get; set; }
        public string Sectors { get; set; }
        public string TaskDescription { get; set; }
    }
}