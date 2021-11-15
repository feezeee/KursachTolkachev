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
        [Authorize(Roles = "Директор, Администратор")]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return RedirectToAction("List");
            }
            Student student = _context.Students.Include(t => t.Class).ThenInclude(t => t.ClassChar).Include(t => t.Class).ThenInclude(t => t.ClassType).Where(t=>t.Id == id).Select(t => t).FirstOrDefault();
            if (student != null)
            {
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var el in _context.Classes.Include(t => t.ClassChar).Include(t => t.ClassType).OrderBy(t => t.ClassChar.CharName).OrderBy(t => t.ClassType.Number).Select(t => t))
                {
                    list.Add(new SelectListItem { Text = $"{el.ClassInfo()}", Value = el.Id.ToString() });
                }

                ViewBag.Classes = list;
               
                return View(student);
            }
            return RedirectToAction("List");

        }

        [HttpPost]
        [Authorize(Roles = "Директор, Администратор")]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var el in _context.Classes.Include(t => t.ClassChar).Include(t => t.ClassType).OrderBy(t => t.ClassChar.CharName).OrderBy(t => t.ClassType.Number).Select(t => t))
            {
                list.Add(new SelectListItem { Text = $"{el.ClassInfo()}", Value = el.Id.ToString() });
            }

            ViewBag.Classes = list;
            return View(student);
        }




        [HttpGet]
        [Authorize(Roles = "Директор, Администратор")]
        public ViewResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var el in _context.Classes.Include(t => t.ClassChar).Include(t => t.ClassType).OrderBy(t => t.ClassChar.CharName).OrderBy(t => t.ClassType.Number).Select(t => t))
            {
                list.Add(new SelectListItem { Text = $"{el.ClassInfo()}", Value = el.Id.ToString() });
            }

            ViewBag.Classes = list;
            return View();
        }
        
        [Authorize(Roles = "Директор, Администратор")]
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);

                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var el in _context.Classes.Include(t => t.ClassChar).Include(t => t.ClassType).OrderBy(t => t.ClassChar.CharName).OrderBy(t => t.ClassType.Number).Select(t => t))
            {
                list.Add(new SelectListItem { Text = $"{el.ClassInfo()}", Value = el.Id.ToString() });
            }

            ViewBag.Classes = list;
            return View(student);
        }





    }
}
