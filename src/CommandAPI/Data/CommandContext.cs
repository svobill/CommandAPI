using System;
using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data
{
	public class CommandContext : DbContext
	{
		public CommandContext(DbContextOptions<CommandContext> options) : base(options)
		{
			// No code needed for this implementation
		}
		
		public DbSet<Command> CommandItems { get; set; }
	}
}