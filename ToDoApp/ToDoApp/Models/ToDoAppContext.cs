using System;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models.Configurations;

namespace ToDoApp.Models
{
    public class ToDoAppContext:DbContext
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder newBuilder)
        =>newBuilder.ApplyConfiguration(new ToDoConfigurations());

        public DbSet<ToDo> Todo { get; set; }
    }
}
