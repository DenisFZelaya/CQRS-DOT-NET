using System;
using CQRS.Application.DTOs;
using MediatR;

namespace CQRS.Infraestructure.Queries
{
	public record GetTaskById(int Id) : IRequest<TaskItemDto>;
	
}

