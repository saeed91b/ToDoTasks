using System;

namespace Application.DTOs;

public class EditTaskDTO : CreateTaskDTO
{
    public string Id { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
