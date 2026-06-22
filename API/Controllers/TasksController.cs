using System;
using Application.Commands;
using Application.DTOs;
using Application.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class TasksController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<ToDoTask>>> GetTasks()
    {
        return HandleResult(await Mediator.Send(new GetTasksList.Query()));
    }

    [HttpGet("{id}")]
     public async Task<ActionResult<ToDoTask>> GetTask(string id)
    {
         return HandleResult(await Mediator.Send(new GetTask.Query {Id = id}));
    }

    [HttpPost]
    public async Task<ActionResult> CreateTask(CreateTaskDTO taskDTO)
    {
        return HandleResult(await Mediator.Send(new CreateTask.Command {TaskDTO = taskDTO}));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(string id)
    {
        return HandleResult(await Mediator.Send(new DeleteTask.Command {Id = id}));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditTask(string id, EditTaskDTO taskDTO)
    {
        taskDTO.Id = id;
        return HandleResult(await Mediator.Send(new EditTask.Command {TaskDTO = taskDTO}));
    }
}
