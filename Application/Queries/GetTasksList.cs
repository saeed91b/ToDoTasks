using System;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries;

public class GetTasksList
{
    public class Query: IRequest<Result<List<ToDoTask>>> {}

    public class Handler(DataContext context) : IRequestHandler<Query, Result<List<ToDoTask>>>
    {
        public async Task<Result<List<ToDoTask>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var tasks = await context.ToDoTasks.ToListAsync(cancellationToken);
            
            return Result<List<ToDoTask>>.Success(tasks);
        }
    }
}
