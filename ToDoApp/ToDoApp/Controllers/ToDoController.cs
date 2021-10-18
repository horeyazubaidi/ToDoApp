using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;


namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        /*
         * Data Base 
         */
        readonly ToDoAppContext Context;
        public ToDoController(ToDoAppContext context)
            => Context = context;

        /*
         * Main Tasks Page, Contains all tasks available in DataBase
         */
        public IActionResult Index()
        {
             var ToDoList = Context.Todo.ToList();

            return View(ToDoList);
        }

        /*
         * Get : for Create <New Todo> method, fetch the Create Page 
         */
        public IActionResult Create()
        {

            return View();
        }

        /*
         * Post : for Create <New ToDo> method, Update new ToDo to Database
         */
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

        /*
         * Get : for Delete <Todo> method, go to the Delete Page
         */
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

        /*
         * Post : for Delete <ToDo> method, Remove  ToDo from Database
         */
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

        /*
         * Get : for Update <ToDo> method, Update  ToDo to Database
         */
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

        /*
         * Post : for Update <ToDo> method, Update  ToDo to Database
         */
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
