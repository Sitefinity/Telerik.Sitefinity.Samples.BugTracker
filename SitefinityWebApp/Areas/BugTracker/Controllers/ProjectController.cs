using System;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.Areas.BugTracker.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            return this.View("ProjectMaster", this.GetProjects());
        }

        private IQueryable<DynamicContent> GetProjects()
        {
            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();
            Type projectType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.BugTracking.Project");

            var myCollection = dynamicModuleManager.GetDataItems(projectType).Where(p => p.Status == ContentLifecycleStatus.Live);

            return myCollection;
        }
    }
}