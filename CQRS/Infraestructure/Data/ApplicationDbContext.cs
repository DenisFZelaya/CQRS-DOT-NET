using System;
using CQRS.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infraestructure.Data
{
	public class ApplicationDbContext: DbContext
	{
		public DbSet<TaskItem> TaskItems { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
			
		}
	}
}

