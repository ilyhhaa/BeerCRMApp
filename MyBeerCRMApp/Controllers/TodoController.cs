using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TodoManager.Models;

namespace TodoManager.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        TodoDbContext todoDb;
        
        public TodoController(TodoDbContext context)
        {
            todoDb = context;
        }

        public async Task<IActionResult> TodoIndex()
        {
            return View(await todoDb.Todo.ToListAsync());
        }


        [Authorize]
        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TodoModel model)
        {
            todoDb.Todo.Add(model);
            await todoDb.SaveChangesAsync();
            return Redirect("TodoIndex");

        }


        [Authorize]
        [HttpPost]

        public async Task<IActionResult> DeleteTask(int? id)
        {
            if (id != null)
            {
                TodoModel model = todoDb.Todo.FirstOrDefault(x => x.id == id);
                if (model != null)
                {
                    todoDb.Remove(model);
                    todoDb.SaveChanges();
                    return View(model);

                }
                    
                    
            }

            return NotFound();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditTask(int? id)
        {
            if (id != null)
            {
                TodoModel? model = todoDb.Todo.FirstOrDefault(x=>x.id == id);
                if(model != null)
                {
                    return View(model);
                }
                

            }
            return NotFound();
        }
        [Authorize]
        public async Task<IActionResult>EditTask(TodoModel model)
        {
            todoDb.Todo.Update(model);
            await todoDb.SaveChangesAsync();
            return RedirectToAction("TodoIndex");
        }


    }
}

















