using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using TaskManagement.Models;
using TaskManagement.ViewModels.TaskViewModel;

namespace TaskManagement.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly TaskManagementDbContext context;

        public TaskItemController(TaskManagementDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<TaskItem> taskItems = context.Tasks.ToList();
            return View(taskItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItemCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            context.Tasks.Add(new TaskItem { Title = model.Title, Description = model.Description, Status = model.Status });
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var taskItem = context.Tasks.Find(id);

            if (taskItem is null)
            {
                return NotFound();
            }
            return View(taskItem);
        }

        [HttpPost]
        public IActionResult Edit(int id, TaskItem model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taskItem = context.Tasks.FirstOrDefault(t => t.Id == id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return View(taskItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var taskItem = context.Tasks.Find(id);
            context.Tasks.Remove(taskItem);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}