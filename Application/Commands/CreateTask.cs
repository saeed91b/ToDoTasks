using System;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Commands;

public class CreateTask
{
    public class Command : IRequest<Result<string>>
    {
        public required CreateTaskDTO TaskDTO { get; set; }
    }

    public class Handler(DataContext context, IMapper mapper) : IRequestHandler<Command, Result<string>>
    {
        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var task = mapper.Map<ToDoTask>(request.TaskDTO);

            context.ToDoTasks.Add(task);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            return result ? Result<string>.Success(task.Id) : Result<string>.Failure("Problem creating task!", 400);
        }
    }
}
