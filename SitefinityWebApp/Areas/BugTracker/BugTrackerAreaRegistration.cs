using System.Web.Mvc;

namespace SitefinityWebApp.Areas.BugTracker
{
    public class BugTrackerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BugTracker";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            if (context.Routes["BugTracker_default"] == null)
            {
                context.MapRoute("BugTracker_default", "BugTracker/{controller}/{action}/{id}", new { action = "Index", id = "" });                
            }
        }
    }
}