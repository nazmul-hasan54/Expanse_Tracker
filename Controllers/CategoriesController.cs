using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using expanse_Tracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace expanse_Tracker.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ExpanseDbContext db;
        public CategoriesController(ExpanseDbContext db) 
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.ExpenseCategories.ToList());
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var p = db.ExpenseCategories.Where(x => x.Id == id).FirstOrDefault();
            return View(p);
        }
        [HttpPost]
        public IActionResult CreateorEdit(ExpenseCategory c)
        {
            if (c.Id > 0)
            {
                db.ExpenseCategories.Update(c);
                db.SaveChanges();
            }
            else
            {
                db.ExpenseCategories.Add(c);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var p = db.ExpenseCategories.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
