using System;
using System.Runtime.CompilerServices;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Commands;

public class EditTask
{
    public class Command : IRequest<Result<Unit>>
    {
        public required EditTaskDTO TaskDTO { get; set; }
    }

    public class Handler(DataContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var task = await context.ToDoTasks.FindAsync([request.TaskDTO.Id], cancellationToken);

            if (task is null) return Result<Unit>.Failure("Task not found!", 404);

            mapper.Map(request.TaskDTO, task);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

             return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem editing the task!", 400);
        }
    }
}
