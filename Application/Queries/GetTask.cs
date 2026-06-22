using System;
using System.Security.Cryptography.X509Certificates;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries;

public class GetTask
{
    public class Query: IRequest<Result<ToDoTask>>
    {
        public required string Id { get; set; }
    }

    public class Handler(DataContext context) : IRequestHandler<Query, Result<ToDoTask>>
    {
        public async Task<Result<ToDoTask>> Handle(Query request, CancellationToken cancellationToken)
        {
            var task = await context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (task == null) return Result<ToDoTask>.Failure("Task not found", 404);

            return Result<ToDoTask>.Success(task);
        }
    }
}
