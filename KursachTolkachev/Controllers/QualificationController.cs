using KursachTolkachev.Data;
using KursachTolkachev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Controllers
{
    public class QualificationController : Controller
    {
        private ApplicationDbContext _context;
        public QualificationController(ApplicationDbContext context)
        {
            _context = context;
        }


        //[Authorize(Roles = "Директор, Администратор")]
        public ViewResult List(Qualification qualification)
        {
            var qualifications = _context.Qualifications.Select(t => t);
            return View(qualifications);
        }


        [HttpGet]
        public ViewResult Create()
        {            
            ViewBag.WhatEdit = "Добавление квалификации";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualification);

                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(qualification);
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return RedirectToAction("List");
            }
            Qualification qualification = _context.Qualifications.Include(t=>t.Workers).Where(t => t.Id == id).Select(t => t).FirstOrDefault();
            if (qualification != null)
            {
                return View(qualification);
            }
            return RedirectToAction("List");

        }


        [HttpPost]
        public async Task<IActionResult> Edit(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(qualification).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            qualification.Workers = _context.Workers.Where(t => t.QualificationId == qualification.Id).ToList();
            return View(qualification);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Qualification qualification = _context.Qualifications.Include(t => t.Workers).Where(t => t.Id == id).FirstOrDefault();
            if (qualification == null || qualification.Workers.Count != 0)
            {
                return RedirectToAction("List");
            }

            return View(qualification);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            Qualification qualification = _context.Qualifications.Include(t => t.Workers).Where(t => t.Id == id).FirstOrDefault();
            if (qualification == null || qualification.Workers.Count != 0)
            {
                return RedirectToAction("List");
            }
            _context.Qualifications.Remove(qualification);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
