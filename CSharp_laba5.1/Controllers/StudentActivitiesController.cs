using CSharp_laba5._1.Domains;
using CSharp_laba5._1.Domains.Entities;
using CSharp_laba5._1.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_laba5._1.Controllers
{
    public class StudentActivitiesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment; //хостинг окружение для сохранения картинок

        public StudentActivitiesController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            //ViewBag.TextField = dataManager.TextFields.GetTextField("PageGroups");
            return View(dataManager.StudentActivities.GetStudentActivities());
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default ? new StudentActivity() : dataManager.StudentActivities.GetStudentActivity(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(StudentActivity model)
        {
            if (ModelState.IsValid)
            {
                //if(titleImageFile != null)
                //{
                //    model.InmagePath = titleImageFile.FileName;
                //    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create)) //картинки сохраняются в папку images
                //    {
                //        titleImageFile.CopyTo(stream);
                //    }
                //}
                dataManager.StudentActivities.AddOrUpdateStudentActivity(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController()); ;
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.StudentActivities.DeleteStudentActivity(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
