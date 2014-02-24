using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using SitefinityWebApp.Areas.BugTracker.Model;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.Areas.BugTracker.Controllers
{
    public class BugController : Controller
    {
        private Type bugType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.BugTracking.Bug");
        private Type projectType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.BugTracking.Project");

        public ActionResult Index()
        {
            Guid projectId = new Guid(this.ControllerContext.RouteData.Values["id"].ToString());

            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();

            Guid masterProjectId = dynamicModuleManager.GetDataItem(this.projectType, projectId).OriginalContentId;

            return View("BugMaster", this.GetBugsByProject(masterProjectId));
        }

        public ActionResult CreateBug()
        {
            return View("BugForm");
        }

        [HttpPost]
        public ActionResult SaveBug(BugModel bug)
        {
            Guid projectId = new Guid(this.ControllerContext.RouteData.Values["id"].ToString());

            SystemManager.RunWithElevatedPrivilegeDelegate worker = new SystemManager.RunWithElevatedPrivilegeDelegate(SaveBugWorker);
            SystemManager.RunWithElevatedPrivilege(worker, new object[] { bug, projectId });

            return this.RedirectToAction("Index", "Bug", new { id = projectId });
        }

        public void SaveBugWorker(object[] args)
        {
            BugModel bug = args.SingleOrDefault(o => o.GetType() == typeof(BugModel)) as BugModel;
            Guid liveProjectId = new Guid(args.SingleOrDefault(o => o.GetType() == typeof(Guid)).ToString());

            if (bug == null)
            {
                return;
            }

            if (liveProjectId == Guid.Empty)
            {
                return;
            }

            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();

            Guid masterProjectId = dynamicModuleManager.GetDataItem(this.projectType, liveProjectId).OriginalContentId;

            var newBug = dynamicModuleManager.CreateDataItem(this.bugType);
            newBug.SetValue("Title", bug.Title);
            newBug.UrlName = Regex.Replace(bug.Title.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
            newBug.SetValue("Description", bug.Description);
            newBug.SetValue("Priority", bug.Priority);
            newBug.SetValue("SystemParentId", masterProjectId);
            newBug.ApprovalWorkflowState = "Draft";

            dynamicModuleManager.SaveChanges();
        }

        private IQueryable<DynamicContent> GetBugsByProject(Guid projectId)
        {
            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();

            var bugs = dynamicModuleManager.GetDataItems(this.bugType).Where(d => d.SystemParentId == projectId && d.Status == ContentLifecycleStatus.Live);

            return bugs;
        }
    }
}