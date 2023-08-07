using System;
using CQRS.Application.DTOs;
using CQRS.Domain;
using CQRS.Infraestructure.Commands;
using CQRS.Infraestructure.Data;
using MediatR;

namespace CQRS.Application.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDbContext _context;

        public CreateTaskHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description
            };

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync(cancellationToken);

            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
            
        }
    }
}

