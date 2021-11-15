using KursachTolkachev.Data;
using KursachTolkachev.Models;
using Microsoft.AspNetCore.Authorization;
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
            var classes = _context.Classes.Include(t=>t.ClassroomTeacher).Include(t=>t.ClassType).Include(t=>t.ClassChar).OrderBy(t => t.ClassChar.CharName).AsEnumerable().GroupBy(t=>t.ClassType.Number).OrderBy(t=>t.Key).Select(t => t);
            return View(classes);
        }



        [HttpGet]
        [Authorize(Roles = "Директор, Администратор")]
        public ViewResult Create()
        {
            ViewBag.ClassChars = new SelectList(_context.ClassChars, "Id", "CharName");
            ViewBag.ClassTypes = new SelectList(_context.ClassTypes, "Id", "Number");
            ViewBag.Teachers = new SelectList(_context.Workers.Where(t=>t.Position.Name == "Учитель").Select(t=>t), "Id", "LastName");
            ViewBag.WhatCreate = "Создание нового класса";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Директор, Администратор")]
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
            Class myClass = _context.Classes.Where(t => t.Id == id).Include(t => t.ClassChar).Include(t => t.ClassType).Include(t => t.Students).Include(t=>t.Schedules).Include(t => t.ClassroomTeacher).Include(t=>t.Subjects).FirstOrDefault();
            if (myClass == null)
            {
                return RedirectToAction("List");
            }

            return View(myClass);
        }


        [HttpGet]
        [Authorize(Roles = "Директор, Администратор")]
        public IActionResult Delete(int? id)
        {
            Class myClass = _context.Classes.Include(t => t.Subjects).Include(t=>t.Students).Where(t => t.Id == id).FirstOrDefault();
            if (myClass == null || myClass.Students.Count != 0)
            {
                return RedirectToAction("List");
            }

            return View(myClass);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Директор, Администратор")]
        public IActionResult DeleteConfirmed(int? id)
        {
            Class myClass = _context.Classes.Include(t => t.Subjects).Include(t => t.Students).Where(t => t.Id == id).FirstOrDefault();
            if (myClass == null || myClass.Students.Count != 0)
            {
                return RedirectToAction("List");
            }

            foreach(var sub in myClass.Schedules)
            {
                _context.Schedules.Remove(sub);
            }

            _context.Classes.Remove(myClass);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
