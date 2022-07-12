using TaskManager.Models;

namespace TaskManager.Services;

public static class TaskService
{
    static List<Models.Task> Tasks { get; }
    static int nextId = 3;
    static TaskService()
    {
        Tasks = new List<Models.Task>
        {
            new Models.Task
            { 
                Id = 1, 
                Description = "This is task-1", 
                Priority = 1,
                Status = "STARTED",
                CustomerId = 3,
            },
            new Models.Task
            {
                Id = 2,
                Description = "This is task-2",
                Priority = 2,
                Status = "STARTED",
                CustomerId = 5,
            }
        };
    }

    public static List<Models.Task> GetAll() => Tasks;

    public static Models.Task? Get(int id) => Tasks.FirstOrDefault(t => t.Id == id);


    public static void Add(Models.Task task)
    {
        task.Id = nextId++;
        Tasks.Add(task);
    }

    public static void Update(Models.Task task)
    {
        var index = Tasks.FindIndex(t => t.Id == task.Id);
        if (index == -1)
            return;
        
        Tasks[index] = task;
    }
}