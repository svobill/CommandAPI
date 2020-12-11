using System;
using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    // Repository Interface
	public interface ICommandAPIRepo
	{
		bool SaveChanges();
		
		IEnumerable<Command> GetAllCommands();
		Command GetCommandByID(int id);
		void CreateCommand();
		void UpdateCommand();
		void DeleteCommand();
	}
}