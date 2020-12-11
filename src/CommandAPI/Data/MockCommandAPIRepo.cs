using System;
using System.Collections.Generic;
using CommandAPI.Models;
	
namespace CommandAPI.Data
{
	public class MockCommandAPIRepo : ICommandAPIRepo
	{
		public void CreateCommand(Command cmd)
		{
			throw new System.NotImplementedException();
		}
		
		public void DeleteCommand(Command cmd)
		{
			throw new System.NotImplementedException();
		}
		
		public IEnumerable<Command> GetAllCommands()
		{
			var commands = new List<Command>
			{
				new Command 
				{
					ID = 0,
					CommandLine = "dotnet ef migrations add <Name of Migration>",
					HowTo = "How to generate a migration",
					Platform = ".NET Core EF"
				},
				new Command 
				{
					ID = 1,
					CommandLine = "dotnet ef database update",
					HowTo = "Run migrations",
					Platform = ".NET Core EF"
				},	
				new Command 
				{
					ID = 2,
					CommandLine = "dotnet ef migrations list",
					HowTo = "List active migrations",
					Platform = ".NET Core EF"
				}					
			};
			
			return commands;
		}
		
		public Command GetCommandByID(int id)
		{
			return new Command 
				{
					ID = 0,
					CommandLine = "dotnet ef migrations add <Name of Migration>",
					HowTo = "How to generate a migration",
					Platform = ".NET Core EF"
				};
		}
		
		public bool SaveChanges()
		{
			return false;
		}
		
		public void UpdateCommand(Command cmd)
		{
			throw new System.NotImplementedException();
		}
	}
}