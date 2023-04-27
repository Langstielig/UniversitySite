using CSharp_laba5._1.Domains;
using CSharp_laba5._1.Domains.Entities;
using CSharp_laba5._1.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_laba5._1.Controllers
{
    public class GroupsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment; //хостинг окружение для сохранения картинок

        public GroupsController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            //ViewBag.TextField = dataManager.TextFields.GetTextField("PageGroups");
            return View(dataManager.Groups.GetGroups());
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default ? new Group() : dataManager.Groups.GetGroup(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Group model)
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
                dataManager.Groups.AddOrUpdateGroup(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController()); ;
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.Groups.DeleteGroup(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        public IActionResult AddStudent(int id, ClassForName nameOfStudent)
        {
            if (dataManager.Students.isNameExists(nameOfStudent))
            {
                dataManager.Groups.AddStudent(id, nameOfStudent);
            }
            return View(nameOfStudent);
        }
    }
}
