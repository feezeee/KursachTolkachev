//using KursachTolkachev.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using KursachTolkachev.Data;
//using Microsoft.AspNetCore.Mvc.Rendering;

using KursachTolkachev.Data;
using KursachTolkachev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Controllers
{
    public class WorkerController : Controller
    {
        private ApplicationDbContext _context;
        public WorkerController(ApplicationDbContext context)
        {
            _context = context;
        }


        //[Authorize(Roles = "Директор, Администратор")]
        public ViewResult List(Worker worker)
        {
            var workers = _context.Workers.Include(t => t.Position).Include(t => t.Qualification).Include(t => t.AccessRight).Select(t => t);
            return View(workers);
        }


        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
            ViewBag.Qualifications = new SelectList(_context.Qualifications, "Id", "Name");
            ViewBag.AccessRights = new SelectList(_context.AccessRights, "Id", "Name");
            ViewBag.WhatEdit = "Добавление работника";
            //ViewBag.Positions = new SelectList(_context.Positions, "Id", "PositionName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worker);

                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return RedirectToAction("List");
            }
            Worker worker = _context.Workers.Include(t => t.Position).Include(t => t.Qualification).Include(t => t.AccessRight).Where(t => t.Id == id).Select(t => t).FirstOrDefault();
            if (worker != null)
            {
                ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
                ViewBag.Qualifications = new SelectList(_context.Qualifications, "Id", "Name");
                ViewBag.AccessRights = new SelectList(_context.AccessRights, "Id", "Name");
                return View(worker);
            }
            return RedirectToAction("List");

        }


        [HttpPost]
        public async Task<IActionResult> Edit(Worker worker)
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
                _context.Entry(worker).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }

            ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
            ViewBag.Qualifications = new SelectList(_context.Qualifications, "Id", "Name");
            ViewBag.AccessRights = new SelectList(_context.AccessRights, "Id", "Name");
            return View(worker);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Worker worker = _context.Workers.Find(id);
            if (worker == null)
            {
                //return HttpNotFound();
            }
            else if (worker?.Id == AuthorizedUser.GetInstance().GetWorker()?.Id)
            {
                return RedirectToRoute("default", new { controller = "Worker", action = "Edit", id = id });
            }

            return View(worker);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            Worker worker = _context.Workers.Find(id);
            if (worker == null)
            {
                //return HttpNotFound();
            }
            _context.Workers.Remove(worker);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
