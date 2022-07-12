using TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Repository
{
    public interface ITaskRepoe
    {
        // CRUD on data store

        Models.Task GetTask(int id);

        List<Models.Task> GetTasks();

        Models.Task CreateTask(Models.Task emp);

        Models.Task UpdateTask(Models.Task emp);

        Models.Task DeleteTask(int id);

    }
}
