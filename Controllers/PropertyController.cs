using MatrixTask.Entity;
using MatrixTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MatrixTask.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ApplicationContext _context;
        public PropertyController(ApplicationContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
           var data =  _context.Properties.Include(p => p.Category).ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = _context.Categories.ToList().Select(i => new CategoryViewModel { Name = i.Name, parentCategoryId = i.CategoryId });
            ViewBag.ParentCategories = new SelectList(categories, "parentCategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(propertyViewModel  p)
        {

            if (ModelState.IsValid)
            {
                MatrixTask.Entity.Property  pp = new MatrixTask.Entity.Property()
                {
                 Name = p.Name,
                 CategoryId = p.CategoryId,
                };
                _context.Properties.Add(pp);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home"); // Redirect to the desired page
            }

            var categories = _context.Categories.ToList().Select(i => new CategoryViewModel { Name = i.Name, parentCategoryId = i.CategoryId });
            ViewBag.ParentCategories = new SelectList(categories, "parentCategoryId", "Name");
            return View(p);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var property = _context.Properties.Include(p => p.Category).SingleOrDefault(p => p.PropertyId == Id);
            if (property == null)
            {
                return BadRequest();
            }
            propertyViewModel PropertyVm = new propertyViewModel()
            { 
                Id = property.PropertyId,
                Name= property.Name,
                CategoryId= property.CategoryId
            };
            var categories = _context.Categories.ToList().Select(i => new CategoryViewModel { Name = i.Name, parentCategoryId = i.CategoryId });
            ViewBag.ParentCategories = new SelectList(categories, "parentCategoryId", "Name", PropertyVm);
            return View(PropertyVm);
        }
        [HttpPost]
        public IActionResult Edit(propertyViewModel inp)
        {

            if (ModelState.IsValid)
            {
                var property = _context.Properties.Include(p => p.Category).SingleOrDefault(p => p.PropertyId == inp.Id);
                if (property == null)
                {
                    return BadRequest();
                }
                property.Name = inp.Name;
                property.CategoryId = inp.CategoryId;
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }

            var categories = _context.Categories.ToList().Select(i => new CategoryViewModel { Name = i.Name, parentCategoryId = i.CategoryId });
            ViewBag.ParentCategories = new SelectList(categories, "parentCategoryId", "Name", inp);
            return View(inp);
           
        }

    }
}
