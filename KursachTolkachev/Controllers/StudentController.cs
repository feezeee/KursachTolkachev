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
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ViewResult List(Student student)
        {
            var students = _context.Students.Include(t => t.Class).ThenInclude(t=>t.ClassChar).Include(t => t.Class).ThenInclude(t => t.ClassType).Select(t => t);
            return View(students);
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return RedirectToAction("List");
            }
            Student student = _context.Students.Include(t => t.Class).ThenInclude(t => t.ClassChar).Include(t => t.Class).ThenInclude(t => t.ClassType).Where(t=>t.Id == id).Select(t => t).FirstOrDefault();
            if (student != null)
            {
                //List<SelectList> list = new List<SelectList>();
                //foreach (var el in _context.Classes)
                //{
                //    list.Add(new SelectListItem { Selected= true, Text})
                //}
                ViewBag.Classes = new SelectList(_context.Classes.Include(t => t.ClassChar).Include(t => t.ClassType).Select(t=>t), "Id", "ClassType.Name");
                return View(student);
            }
            return RedirectToAction("List");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                //if (worker.Id == AuthorizedUser.GetInstance().GetWorker().Id)
                //{
                //    worker.Position = _context.Positions.Find(worker.PositionId);
                //    worker.Gender = _context.Genders.Find(worker.GenderId);
                //    AuthorizedUser.GetInstance().ClearUser();
                //    AuthorizedUser.GetInstance().SetUser(worker);
                //}
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }

            ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
            ViewBag.Qualifications = new SelectList(_context.Qualifications, "Id", "Name");
            ViewBag.AccessRights = new SelectList(_context.AccessRights, "Id", "Name");
            return View(student);
        }




        [HttpGet]
        public ViewResult Create()
        {
            //ViewBag.ClassChars = new SelectList(_context.ClassChars, "Id", "CharName");
            //ViewBag.ClassTypes = new SelectList(_context.ClassTypes, "Id", "Name");
            //ViewBag.Teachers = new SelectList(_context.Workers.Where(t => t.Position.Name == "Учитель").Select(t => t), "Id", "LastName");
            //ViewBag.WhatCreate = "Создание нового класса";
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





    }
}
