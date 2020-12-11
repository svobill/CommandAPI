using System;
using System.Collections.Generic;
using System.Linq;
using CommandAPI.Models;

namespace CommandAPI.Data
{
	public class SqlCommandAPIRepo : ICommandAPIRepo
	{
		private readonly CommandContext _context;
		
		public SqlCommandAPIRepo(CommandContext context)
		{
			_context = context;
		}
		
		public void CreateCommand()
		{
			throw new System.NotImplementedException();
		}
		
		public void DeleteCommand()
		{
			throw new System.NotImplementedException();
		}
		
		public IEnumerable<Command> GetAllCommands()
		{
			return _context.CommandItems.ToList();
		}
		
		public Command GetCommandByID(int id)
		{
			return _context.CommandItems.FirstOrDefault(param => param.ID == id);
		}
		
		public bool SaveChanges()
		{
			throw new System.NotImplementedException();
		}
		
		public void UpdateCommand()
		{
			throw new System.NotImplementedException();
		}
	}
}