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
    public class SubjectController : Controller
    {
        private ApplicationDbContext _context;
        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }


        //[Authorize(Roles = "Директор, Администратор")]
        public ViewResult List(Subject subject)
        {
            var subjects = _context.Subjects.Include(t=>t.Worker).Select(t => t);
            return View(subjects);
        }


        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.WhatEdit = "Добавление предмета";
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var el in _context.Workers.Include(t => t.Position).Where(t => t.Position.Name == "Учитель").Select(t => t))
            {
                list.Add(new SelectListItem { Text = $"{el.FIO()}", Value = el.Id.ToString() });
            }
            ViewBag.Workers = list;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);

                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var el in _context.Workers.Include(t => t.Position).Where(t => t.Position.Name == "Учитель").Select(t => t))
            {
                list.Add(new SelectListItem { Text = $"{el.FIO()}", Value = el.Id.ToString() });
            }
            ViewBag.Workers = list;
            return View(subject);
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return RedirectToAction("List");
            }
            Subject subject = _context.Subjects.Include(t => t.Worker).Include(t=>t.Classes).Include(t=>t.Schedules).Where(t => t.Id == id).Select(t => t).FirstOrDefault();

            if (subject != null)
            {
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var el in _context.Workers.Include(t => t.Position).Where(t => t.Position.Name == "Учитель").Select(t => t))
                {
                    list.Add(new SelectListItem { Text = $"{el.FIO()}", Value = el.Id.ToString() });
                }
                ViewBag.Workers = list;
                return View(subject);
            }
            return RedirectToAction("List");

        }


        [HttpPost]
        public async Task<IActionResult> Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(subject).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var el in _context.Workers.Include(t => t.Position).Where(t => t.Position.Name == "Учитель").Select(t => t))
            {
                list.Add(new SelectListItem { Text = $"{el.FIO()}", Value = el.Id.ToString() });
            }
            ViewBag.Workers = list;

            subject.Schedules = _context.Schedules.Where(t => t.SubjectId == subject.Id).ToList();           
            return View(subject);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Subject subject = _context.Subjects.Include(t => t.Worker).Where(t => t.Id == id).Include(t => t.Classes).FirstOrDefault();
            if (subject == null || subject.Classes.Count != 0)
            {
                return RedirectToAction("List");
            }

            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            Subject subject = _context.Subjects.Include(t => t.Worker).Where(t => t.Id == id).Include(t => t.Classes).FirstOrDefault();
            if (subject == null || subject.Classes.Count != 0)
            {
                return RedirectToAction("List");
            }
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
