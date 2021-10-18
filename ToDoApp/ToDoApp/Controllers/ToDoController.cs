using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
   // [Route("[controller]")]
    public class ToDoController : Controller
    {
        readonly ToDoAppContext Context;
        public ToDoController(ToDoAppContext context)
            => Context = context;
        
        public IActionResult Index()
        {
             var ToDoList = Context.Todo.ToList();

            return View(ToDoList);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                Context.Add(todo);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }


        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var todo = Context.Todo.Find(id);
            if(todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        [HttpPost]
        public IActionResult DeletePost(Guid? id)
        {
            var todo = Context.Todo.Find(id);
            if(todo == null)
            {
                return NotFound();
            }
            Context.Remove(todo);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid? id)
        {
            ViewBag.selection = new List<string> { "New", "Completed" };

            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var todo = Context.Todo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ToDo todo)
        {
           
            if (ModelState.IsValid)
            {

                Context.Update(todo);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

    }
}
