using CSharp_laba5._1.Domains;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_laba5._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)  
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetTextField("PageIndex"));
        }

        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextField("PageContacts"));
        }
    }
}
