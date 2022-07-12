using TaskManager.Models;

namespace TaskManager.Services;

public static class TaskProcessorController
{
    static List<Models.Task> ProcessedTasks { get; }
    static int nextId = 3;


    static ProcessedTaskService()
    {
        ProcessedTasks = new List<Models.Task>
        {
            new Models.Task
            { 
                Id = 9, 
                Description = "This is task-9", 
                Priority = 9,
                Status = "COMPLETED",
                CustomerId = 21,
            },
            new Models.Task
            {
                Id = 10,
                Description = "This is task-10",
                Priority = 10,
                Status = "COMPLETED",
                CustomerId = 55,
            }
        };
    }

    public static List<Models.Task> GetAll() => ProcessedTasks;
    public static Models.Task? Get(int id) => ProcessedTasks.FirstOrDefault(t => t.Id == id);

    public static void Add(Models.Task task)
    {
        task.Id = nextId++;
        ProcessedTasks.Add(task);
    }

    public static void Update(Models.Task task)
    {
        var index = ProcessedTasks.FindIndex(t => t.Id == task.Id);
        if (index == -1)
            return;
        
        ProcessedTasks[index] = task;
    }

}