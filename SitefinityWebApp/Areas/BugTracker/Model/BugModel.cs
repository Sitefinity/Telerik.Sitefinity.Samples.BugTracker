using System;

namespace SitefinityWebApp.Areas.BugTracker.Model
{
    public class BugModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Priority { get; set; }
        public string[] BugStatus { get; set; }
    }
}