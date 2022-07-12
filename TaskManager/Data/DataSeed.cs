using TaskManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSAPI.Data
{
    public static class DataSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>().HasData(
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
            );
        }
    }
}
