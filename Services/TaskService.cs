using AppWeb1.Models;

namespace AppWeb.Services
{
    public static class TaskService
    {
        private static List<TaskItem> _tasks = new()
        {
            new TaskItem { Id = 1, Titulo = "Aprender ASP.NET Core MVC", Completado = false },
            new TaskItem { Id = 2, Titulo = "Crear proyecto sin base de datos", Completado = true }
        };

        public static List<TaskItem> GetAll() => _tasks;

        public static TaskItem GetById(int id) =>
            _tasks.FirstOrDefault(t => t.Id == id);

        public static void Add(TaskItem task)
        {
            task.Id = _tasks.Max(t => t.Id) + 1;
            _tasks.Add(task);
        }

        public static void Update(TaskItem task)
        {
            var existing = GetById(task.Id);
            if (existing == null) return;

            existing.Titulo = task.Titulo;
            existing.Completado = task.Completado;
        }

        public static void Delete(int id)
        {
            var task = GetById(id);
            if (task != null)
                _tasks.Remove(task);
        }
    }
}
