using E_Learning___Summer_Courses_.Data;
using E_Learning___Summer_Courses_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Learning___Summer_Courses_.Controllers
{
    public class StudentsController : Controller
    {
        ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetIndexView(string? search)
        {
            ViewBag.Search = search;
            if (string.IsNullOrEmpty(search) == true)
            {
                return View("Index", _context.Students.ToList());
            }
            else
            {
                return View("Index", _context.Students.Where(d => d.FullName.Contains(search) || d.StudentAccount.Contains(search)).ToList());
            }
        }

        [HttpGet]
        public IActionResult GetDetailsView(int id)
        {
            Student st =_context.Students.Include(e=>e.Subject).FirstOrDefault(s => s.Id == id);
            ViewBag.Currentstd = st;
            if (st == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", st);
            }
        }

        [HttpGet]
        public IActionResult GetCreateView()
        {
            
            ViewBag.AllSubjects = _context.Subjects.ToList();
            return View("Create");
        }

        [HttpPost]
        public IActionResult AddNew(Student student)
        {
           

            if (ModelState.IsValid == true)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllSubjects = _context.Subjects.ToList();
                return View("Create", student);
            }
        }
        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            Student st = _context.Students.FirstOrDefault(su => su.Id == id);
            if (st == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.AllSubjects = _context.Subjects.ToList();
                return View("Edit", st);
            }

        }
        [HttpPost]
        public IActionResult EditCurrent(Student st)
        {
            if (ModelState.IsValid == true)
            {
                _context.Students.Update(st);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                //ViewBag.AllSubjects = _context.Subjects.ToList();
                return View("Edit", st);
            }
        }

       
        public IActionResult GetDeleteView(int id)
        {
            Student st = _context.Students.Include(s => s.Subject).FirstOrDefault(d => d.Id == id);
            if (st == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", st);
            }
        }
        [HttpPost]
        public IActionResult DeleteCurrent(int id)
        {
            Student st = _context.Students.FirstOrDefault(d => d.Id == id);
            _context.Students.Remove(st);
            _context.SaveChanges();
            return RedirectToAction("GetIndexView");

        }
    }

}

