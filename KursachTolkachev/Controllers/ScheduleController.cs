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
    public class ScheduleController : Controller
    {
        private ApplicationDbContext _context;
        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add(int? classId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var el in _context.Subjects.Include(t=>t.Worker))
            {
                list.Add(new SelectListItem { Text = $"{el.SubjectInfo()}", Value = el.Id.ToString() });
            }

            ViewBag.AvailableSubjects = list;
            Schedule schedule = new Schedule();
            schedule.ClassId = classId.Value;
            return View(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);

                await _context.SaveChangesAsync();
                return RedirectToAction("Information", "Class", new { id = schedule.ClassId});
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var el in _context.Subjects.Include(t => t.Worker))
            {
                list.Add(new SelectListItem { Text = $"{el.SubjectInfo()}", Value = el.Id.ToString() });
            }
            ViewBag.AvailableSubjects = list;
            return View(schedule);
        }

        public IActionResult CheckDate(DateTime? Date, int? ClassId)
        {
           
                var res1 = _context.Schedules.Include(t => t.Subject).Where(t => t.Date == Date).Where(t=>t.ClassId == ClassId ).Select(t => t).ToList();
                
                if (res1.Count == 0)
                {
                    return Json(true);
                }
                return Json(false);
        }

        public IActionResult CheckSubject(DateTime? Date, int? SubjectId)
        {
            var res2 = _context.Schedules.Include(t => t.Subject).Where(t => t.Subject.Id == SubjectId).Where(t => t.Date == Date).Select(t => t).ToList();

            if (res2.Count == 0)
            {
                return Json(true);
            }
            return Json(false);

        }

        //public ViewResult List(Schedule schedule)
        //{
        //    if (schedule.Date == DateTime.MinValue)
        //    {
        //        schedule.Date = DateTime.Now;
        //    }
        //    //var workers = _context.Workers.Include(t => t.Position).Include(t => t.Qualification).Include(t => t.AccessRight).Select(t => t);
        //    var res = _context.Schedules.Where(t => t.ClassId == schedule.ClassId).Where(t => t.Date.Date == schedule.Date.Date).Include(t => t.Subject).ThenInclude(t => t.Worker);
        //    ViewBag.Dates = schedule.Date.Date.ToShortDateString();
        //    ViewBag.Id = schedule.ClassId;
        //    return View(res);
        //}


        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (id == 0)
        //    {
        //        return RedirectToAction("List");
        //    }
        //    Worker worker = _context.Workers.Include(t => t.Position).Include(t => t.Qualification).Include(t => t.AccessRight).Where(t => t.Id == id).Select(t => t).FirstOrDefault();
        //    if (worker != null)
        //    {
        //        ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
        //        ViewBag.Qualifications = new SelectList(_context.Qualifications, "Id", "Name");
        //        ViewBag.AccessRights = new SelectList(_context.AccessRights, "Id", "Name");
        //        return View(worker);
        //    }
        //    return RedirectToAction("List");

        //}


        //[HttpPost]
        //public async Task<IActionResult> Edit(Worker worker)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //if (worker.Id == AuthorizedUser.GetInstance().GetWorker().Id)
        //        //{
        //        //    worker.Position = _context.Positions.Find(worker.PositionId);
        //        //    worker.Gender = _context.Genders.Find(worker.GenderId);
        //        //    AuthorizedUser.GetInstance().ClearUser();
        //        //    AuthorizedUser.GetInstance().SetUser(worker);
        //        //}
        //        _context.Entry(worker).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("List");
        //    }

        //    ViewBag.Positions = new SelectList(_context.Positions, "Id", "Name");
        //    ViewBag.Qualifications = new SelectList(_context.Qualifications, "Id", "Name");
        //    ViewBag.AccessRights = new SelectList(_context.AccessRights, "Id", "Name");
        //    return View(worker);
        //}
    }
}
