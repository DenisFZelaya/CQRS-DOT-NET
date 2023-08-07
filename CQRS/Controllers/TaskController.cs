using System;
using CQRS.Application.DTOs;
using CQRS.Infraestructure.Commands;
using CQRS.Infraestructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> GetAll()
        {
            return await _mediator.Send(new GetAllTaskQuery());
        }

        [HttpPost]
        public async Task<TaskItemDto> Create(CreateTaskCommand command)
        {
            var taskItem = await _mediator.Send(command);
            return taskItem;
        }
    }
}

