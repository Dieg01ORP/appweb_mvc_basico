using AppWeb.Services;
using AppWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb1.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View(TaskService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            TaskService.Add(task);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View(TaskService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            TaskService.Update(task);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            return View(TaskService.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            TaskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
