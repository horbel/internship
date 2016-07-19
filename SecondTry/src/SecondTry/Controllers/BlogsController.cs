using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecondTry.Models;

namespace SecondTry.Controllers
{
    public class BlogsController: Controller
    {
        private BloggingContext _context;
        public BlogsController(BloggingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
    }
}
