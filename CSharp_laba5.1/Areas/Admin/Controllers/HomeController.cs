using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_laba5._1.Domains;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_laba5._1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
	{
		private readonly DataManager dataManager;

		public HomeController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public IActionResult Index()
		{
			return View(dataManager.Students.GetStudents());
		}

		//public IActionResult Index2()
		//{
		//	return View(dataManager.Groups.GetGroups());
		//}
	}
}
