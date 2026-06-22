using System;
using Domain;

namespace Persistence;

public class DbSeeder
{
    public static async Task SeedData(DataContext context)
    {
        if (context.ToDoTasks.Any())
            return;
        
        List<ToDoTask> tasks = new()
        {
            new()
            {
                Title = "Task 1",
                Description = "bla bla bla",
            },
            new()
            {
                Title = "Task 2",
                Description = "bla bla bla",
            },
            new()
            {
                Title = "Task 3",
                Description = "bla bla bla",
            }
        };

        context.ToDoTasks.AddRange(tasks);

        await context.SaveChangesAsync();
    }
}
