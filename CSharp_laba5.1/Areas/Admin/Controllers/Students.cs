using System;
using System.Globalization;
using System.IO;
using CSharp_laba5._1.Domains;
using CSharp_laba5._1.Domains.Entities;
using CSharp_laba5._1.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_laba5._1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Students : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment; //хостинг окружение для сохранения картинок

        public Students(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        
        public IActionResult Edit(int id)
        {
            var entity = id == default ? new Student() : dataManager.Students.GetStudent(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Student model, IFormFile titleImageFile)
        {
            if(ModelState.IsValid)
            {
                //if(titleImageFile != null)
                //{
                //    model.InmagePath = titleImageFile.FileName;
                //    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create)) //картинки сохраняются в папку images
                //    {
                //        titleImageFile.CopyTo(stream);
                //    }
                //}
                dataManager.Students.AddOrUpdateStudent(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.Students.DeleteStudent(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        public IActionResult AddActivity(int id, ClassForName nameOfActivity)
        {
            //Student student = dataManager.Students.GetStudent(id);
            if(dataManager.Activities.isNameExists(nameOfActivity.Name))
            {
                dataManager.Students.AddStudentToActivity(id, nameOfActivity.Name);
            }
            return View(nameOfActivity);
        }

        public IActionResult DeleteActivity(int id, ClassForName nameOfActivity)
        {
            //Student student = dataManager.Students.GetStudent(id);
            if(dataManager.Activities.isNameExists(nameOfActivity.Name) &&
                dataManager.StudentActivities.isConnectionExists(id, nameOfActivity.Name))
            {
                dataManager.Students.DeleteActivity(id, nameOfActivity.Name);
            }
            return View(nameOfActivity);
        }
    }
}
