using System;
using Microsoft.AspNetCore.Mvc;
using CSharp_laba5._1.Domains;

namespace CSharp_laba5._1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DataManager dataManager;

        public StudentsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        
        public IActionResult Index(int id)
        {
            if(id != default)
            {
                return View("Show", dataManager.Students.GetStudent(id)); //вывод конкретного студента
            }
            ViewBag.TextField = dataManager.TextFields.GetTextField("PageStudents"); //вывод списка студентов
            return View(dataManager.Students.GetStudents());
        }
    }
}
