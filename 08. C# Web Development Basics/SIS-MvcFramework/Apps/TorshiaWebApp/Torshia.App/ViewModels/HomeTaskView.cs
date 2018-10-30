namespace Torshia.App.ViewModels
{
    public class HomeTaskView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Level { get; set; }

        public string ReportId => "1";
    }
}