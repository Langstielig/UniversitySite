using CSharp_laba5._1.Domains;
using CSharp_laba5._1.Domains.Entities;
using CSharp_laba5._1.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_laba5._1.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment; //хостинг окружение для сохранения картинок

        public ActivitiesController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            //ViewBag.TextField = dataManager.TextFields.GetTextField("PageGroups");
            return View(dataManager.Activities.GetActivities());
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default ? new Activity() : dataManager.Activities.GetActivity(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Activity model)
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
                dataManager.Activities.AddOrUpdateActivity(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController()); ;
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.Activities.DeleteActivity(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        public IActionResult AddStudent(int id, ClassForName nameOfStudent)
        {
            //Activity activity = dataManager.Activities.GetActivity(id);
            if (dataManager.Students.isNameExists(nameOfStudent))
            {
                dataManager.Activities.addActivityToStudent(id, nameOfStudent);
            }
            return View(nameOfStudent);
        }

        public IActionResult DeleteStudent(int id, ClassForName nameOfStudent)
        {
            if(dataManager.Students.isNameExists(nameOfStudent) 
                && dataManager.Activities.isConnectionExists(id, nameOfStudent))
            {
                dataManager.Activities.deleteStudent(id, nameOfStudent);
            }
            return View(nameOfStudent);
        }
    }
}
