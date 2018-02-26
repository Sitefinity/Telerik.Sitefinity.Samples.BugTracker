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
        #region Actions

        public ActionResult Index()
        {
            Guid projectId = new Guid(this.ControllerContext.RouteData.Values["id"].ToString());

            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();

            Guid masterProjectId = dynamicModuleManager.GetDataItem(BugController.projectType, projectId).OriginalContentId;

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

        #endregion

        #region Private methods

        private void SaveBugWorker(object[] args)
        {
            var bugModel = args.SingleOrDefault(o => o.GetType() == typeof(BugModel)) as BugModel;
            var liveProjectId = new Guid(args.SingleOrDefault(o => o.GetType() == typeof(Guid)).ToString());

            if (bugModel == null || liveProjectId == Guid.Empty)
                return;

            var dynamicModuleManager = DynamicModuleManager.GetManager();

            Guid masterProjectId = dynamicModuleManager.GetDataItem(BugController.projectType, liveProjectId).OriginalContentId;

            var newBug = dynamicModuleManager.CreateDataItem(BugController.bugType);
            newBug.SetValue("Title", bugModel.Title);
            newBug.UrlName = Regex.Replace(bugModel.Title.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
            newBug.SetValue("Description", bugModel.Description);
            newBug.SetValue("Priority", bugModel.Priority);
            newBug.SetValue("SystemParentId", masterProjectId);
            newBug.ApprovalWorkflowState = "Draft";

            dynamicModuleManager.SaveChanges();
            dynamicModuleManager.Lifecycle.Publish(newBug);
            dynamicModuleManager.SaveChanges();
        }

        private IQueryable<DynamicContent> GetBugsByProject(Guid projectId)
        {
            var dynamicModuleManager = DynamicModuleManager.GetManager();
            var bugs = dynamicModuleManager
                .GetDataItems(BugController.bugType)
                .Where(d => d.SystemParentId == projectId && d.Status == ContentLifecycleStatus.Live);

            return bugs;
        }

        #endregion

        #region Fields and constants

        private static Type bugType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.BugTracking.Bug");
        private static Type projectType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.BugTracking.Project");

        #endregion
    }
}