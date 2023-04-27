using CSharp_laba5._1.Domains;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_laba5._1.Controllers
{
    public class ShowGroupsController : Controller
    {
        private readonly DataManager dataManager;

        public ShowGroupsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(int id)
        {
            ViewBag.TextField = dataManager.TextFields.GetTextField("PageShowGroups");
            return View(dataManager.Groups.GetGroups());
        }
    }
}
