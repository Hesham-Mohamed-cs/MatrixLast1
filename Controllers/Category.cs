using MatrixTask.Entity;
using MatrixTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MatrixTask.Controllers
{
    public class Category : Controller
    {
        private readonly ApplicationContext _context;
        public Category( ApplicationContext  context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = _context.Categories.ToList().Select(i => new CategoryViewModel{Name = i.Name , parentCategoryId = i.CategoryId});
            ViewBag.ParentCategories = new SelectList(categories, "parentCategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoryViewModel c)
        {
            
            if (ModelState.IsValid)
            {
                MatrixTask.Entity.Category cc = new Entity.Category() { 
                Name = c.Name,
                ParentCategoryId = c.parentCategoryId
                };
                _context.Categories.Add(cc);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home"); // Redirect to the desired page
            }

            var categories = _context.Categories.ToList().Select(i => new CategoryViewModel { Name = i.Name, parentCategoryId = i.CategoryId });
            ViewBag.ParentCategories = new SelectList(categories, "parentCategoryId", "Name");
            return View(c);
        }
    }
}
