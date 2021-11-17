using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (id == null)
                return View();
            else
            {
                var StudentInDb = _context.Students.FirstOrDefault(e => e.Id == id);
                return View(StudentInDb);      
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Student student)
        {
            if (student.Id== 0)
                _context.Students.Add(student);
            else
            {
               _context.Entry<Student>(student).State = EntityState.Modified;
               
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var StudentInDb = _context.Students.Find(id);
            return View(StudentInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete_Data(int id)
        {
            var StudentInDb = _context.Students.Find(id);
            _context.Students.Remove(StudentInDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Filter(string str)
        {
           var result= _context.Students.Where(x => x.FirstName.Contains(str) || x.ClassName.Contains(str)|| x.LastName.Contains(str));

            return View("Index", result);
        }
        

    }
}
