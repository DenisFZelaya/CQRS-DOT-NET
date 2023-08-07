using System;
using CQRS.Application.DTOs;
using CQRS.Infraestructure.Data;
using CQRS.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Application.Handlers
{
	public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskItemDto>>
	{

        private readonly ApplicationDbContext _context;

        public GetAllTaskHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.TaskItems.ToListAsync();

            return task.Select(task => new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            });
        }
    }
}

