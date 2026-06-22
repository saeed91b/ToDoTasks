using System;

namespace Domain;

public class ToDoTask
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public required string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; } = DateTime.UtcNow;
}
