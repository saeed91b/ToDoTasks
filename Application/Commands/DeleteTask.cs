using System;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Commands;

public class DeleteTask
{
    public class Command : IRequest<Result<Unit>>
    {
        public required string Id { get; set; }
    }

    public class Handler(DataContext context) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var task = await context.ToDoTasks.FindAsync([request.Id], cancellationToken);

            if (task is null) return Result<Unit>.Failure("Task not found!", 404);

            context.Remove(task);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem deleting the task!", 400);

        }
    }
}
