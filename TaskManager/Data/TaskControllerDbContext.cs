using TaskManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EMSAPI.Data
{
    public class TaskManagerDbContext : DbContext
    {
        // configuration's like which database and what are objects to be created in the db

        // Database
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options, IConfiguration configuration, ILogger<TaskManagerDbContext> logger):base(options)
        {
            Configuration = configuration;
            _logger = logger;
        }
        public IConfiguration Configuration { get; }
        public ILogger _logger { get; }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var server = Configuration["DbServer"] ?? "localhost";
            var server = Configuration["DbServer"] ?? "ms-sql-server";
            var port = Configuration["DbPort"] ?? "1433"; // Default SQL Server port
            var user = Configuration["DbUser"] ?? "SA"; // Warning do not use the SA account
            var password = Configuration["Password"] ?? "Pa55w0rd2021";
            var database = Configuration["Database"] ?? "TaskControllerDb";

            _logger.LogInformation("Connection string:" + $"Server={server},{port};Database={database};User={user};Password={password}"
               );
            optionsBuilder.UseSqlServer(
                //Configuration.GetConnectionString("DefaultURL")
                //Configuration.GetSection("cs:DefaultURL").Value);
                $"Server={server},{port};Database={database};User={user};Password={password}"
                );
            base.OnConfiguring(optionsBuilder);
        }

        // DML - 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
        }

        // database object to be created - tables 
        public DbSet<Task> Employees { get; set; }

    }
}
