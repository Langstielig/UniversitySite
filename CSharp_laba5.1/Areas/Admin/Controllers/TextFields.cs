using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSharp_laba5._1.Domains;
using CSharp_laba5._1.Domains.Entities;
using CSharp_laba5._1.Service;

namespace CSharp_laba5._1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFields : Controller
    {
        private readonly DataManager dataManager;

        public TextFields(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextField(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFields.UpdateTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
