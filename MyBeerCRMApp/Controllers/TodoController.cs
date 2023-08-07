using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TodoManager.Models;

namespace TodoManager.Controllers
{
    public class TodoController : Controller
    {
        TodoDbContext todoDb;

        public TodoController(TodoDbContext context)
        {
            todoDb = context;
        }

        public async Task <IActionResult> TodoIndex()
        {
            return View(await todoDb.todos.ToListAsync());
        }



        public IActionResult CreateTask()
        {
            return View();
        }

        public async Task <IActionResult> CreateTask(TodoModel model)
        {
            todoDb.todos.Add(model);
           await todoDb.SaveChangesAsync();
            return Redirect("TodoIndex");
            
        }


        [Authorize]
        [HttpPost]

        public async Task<IActionResult> DeleteTask (int? id)
        {
            if (id != null)
            {
                TodoModel model = todoDb.todos.FirstOrDefault(x=> x.id == id);
                if (model != null) return View(model);
            }

            return NotFound();
        }


















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}