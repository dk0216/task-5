using TaskManager.Data;
using TaskManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Repository.DB
{
    public class DBTaskRepo : ITaskRepoe
    {
        TaskManagerDbContext _dbContext = null;
        public DBTaskRepo(TaskManagerDbContext dbContext)
        {
            _dbContext =dbContext;
        }

        public Models.Task CreateTask(Models.Task task)
        {
            _dbContext.Tasks.Add(task); // it actualy add the data into Disconnected database
            _dbContext.SaveChanges(); // commit
            return task;
        }

        public Models.Task DeleteTask(int id)
        {
            Models.Task task = _dbContext.Tasks.FirstOrDefault(e => e.Id == id);
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
            return task;
        }

        public Models.Task GetTask(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(e => e.Id == id);
        }

        public List<Models.Task> GetTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        public Models.Task UpdateTask(Models.Task task)
        {
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
            return task;
        }
    }
}
