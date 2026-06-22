using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<ToDoTask> ToDoTasks { get; set; }
}
