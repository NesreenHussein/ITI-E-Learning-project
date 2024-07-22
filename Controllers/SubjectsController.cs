using E_Learning___Summer_Courses_.Models;
using Microsoft.AspNetCore.Mvc;
using E_Learning___Summer_Courses_.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Learning___Summer_Courses_.Controllers;

public class SubjectsController : Controller
{
    ApplicationDbContext _context;

    public SubjectsController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult GetIndexView(string? search)
    {
        ViewBag.Search = search;
        if (string.IsNullOrEmpty(search) == true)
        {
            return View("Index", _context.Subjects.ToList());
        }
        else
        {
            return View("Index", _context.Subjects.Where(d => d.Name.Contains(search) || d.Description.Contains(search)).ToList());
        }
    }

    [HttpGet]
    public IActionResult GetDetailsView(int id)
    {
        Subject sub = _context.Subjects.Include(s=>s.Students).FirstOrDefault(s => s.Id == id);
        ViewBag.Currentsub = sub;
        if (sub == null)
        {
            return NotFound();
        }
        else
        {
            return View("Details", sub);
        }
    }

    [HttpGet]
    public IActionResult GetCreateView()
    {

        ViewBag.AllStudends = _context.Subjects.ToList();
        return View("Create");
    }

    [HttpPost]
    public IActionResult AddNew(Subject subject)
    {

        if (ModelState.IsValid == true)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return RedirectToAction("GetIndexView");
        }
        else
        {
            ViewBag.AllSubjects = _context.Subjects.ToList();

            return View("Create", subject);
        }
    }
    [HttpGet]
    public IActionResult GetEditView(int id)
    {
        Subject subject = _context.Subjects.FirstOrDefault(su => su.Id == id);
        if (subject == null)
        {
            return NotFound();
        }
        else
        {
            return View("Edit", subject);
        }

    }
    [HttpPost]
    public IActionResult EditCurrent(Subject sub)
    {
        if (ModelState.IsValid == true)
        {
            _context.Subjects.Update(sub);
            _context.SaveChanges();
            return RedirectToAction("GetIndexView");
        }
        else
        {
            return View("Edit", sub);
        }
    }
    public IActionResult GetDeleteView(int id)
    {
        Subject sub = _context.Subjects.Include(s => s.Students).FirstOrDefault(d => d.Id == id);
        if (sub == null)
        {
            return NotFound();
        }
        else
        {
            return View("Delete", sub);
        }
    }
    [HttpPost]
    public IActionResult DeleteCurrent(int id)
    {
        Subject sub = _context.Subjects.FirstOrDefault(d => d.Id == id);
        _context.Subjects.Remove(sub);
        _context.SaveChanges();
        return RedirectToAction("GetIndexView");

    }
}






















