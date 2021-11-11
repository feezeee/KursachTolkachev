using KursachTolkachev.Data;
using KursachTolkachev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Controllers
{
    public class ClassController : Controller
    {
        private ApplicationDbContext _context;
        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }


        //[Authorize(Roles = "Директор, Администратор")]
        public ViewResult List(Class myClass)
        {
            var classes = _context.Classes.Include(t=>t.ClassroomTeacher).Include(t=>t.ClassType).Include(t=>t.ClassChar).Select(t => t).OrderBy(t=>t.ClassType);
            return View(classes);
        }



        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.ClassChars = new SelectList(_context.ClassChars, "Id", "CharName");
            ViewBag.ClassTypes = new SelectList(_context.ClassTypes, "Id", "Name");
            ViewBag.Teachers = new SelectList(_context.Workers.Where(t=>t.Position.Name == "Учитель").Select(t=>t), "Id", "LastName");
            ViewBag.WhatCreate = "Создание нового класса";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Class myClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myClass);

                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Information(int? id)
        {
            Class myClass = _context.Classes.Where(t => t.Id == id).Include(t => t.ClassChar).Include(t => t.ClassType).Include(t => t.Lessons).ThenInclude(t=>t.Schedules).Include(t => t.Students).Include(t => t.ClassroomTeacher).FirstOrDefault();
            if (myClass == null)
            {
                return RedirectToAction("List");
            }

            return View(myClass);
        }
    }
}
