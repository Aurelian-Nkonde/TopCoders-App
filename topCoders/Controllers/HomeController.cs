using System;
using System.Collections.Generic;
using topCoders.Models;
using topCoders.Data;
using Microsoft.AspNetCore.Mvc;
using topCoders.Structure;
using Microsoft.EntityFrameworkCore;

namespace topCoders.Controllers
{
    public class HomeController: Controller
    {
        private readonly ITopCoders _topCodersInterfaceRepo;
        private readonly TopCodersDbContext _databaseContext;

        public HomeController(ITopCoders topCodersInterfaceRepo, TopCodersDbContext databaseContext)
        {
            _topCodersInterfaceRepo = topCodersInterfaceRepo;
            _databaseContext = databaseContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listOfTopCoders = await _topCodersInterfaceRepo.ListOfCoders();
            return View( listOfTopCoders);
        }


        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateACoder()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateACoder(Coder dataCoderFromForm)
        {
            var totalTopCodersInDatabase = await _topCodersInterfaceRepo.ListOfCoders();
            if (totalTopCodersInDatabase.Count() <= 5)
            {
                if(!ModelState.IsValid)
                {
                    return View(dataCoderFromForm);
                }
                _topCodersInterfaceRepo.CreateACoder(dataCoderFromForm);
                return RedirectToAction("Index");
            }
            return View("listIsFull");


        }


        public async Task<IActionResult> DeleteACoder(int? id)
        {
            if (id != 0 && id != null)
            {
               var findindTheActualCoder = await _databaseContext.coders.FirstOrDefaultAsync(n => n.Id == id);
               if (findindTheActualCoder != null)
               {
                   _topCodersInterfaceRepo.DeleteACoder(findindTheActualCoder);
                   return RedirectToAction("Index");
               }
            }
            return RedirectToAction("Index");
            
        }
    }
}