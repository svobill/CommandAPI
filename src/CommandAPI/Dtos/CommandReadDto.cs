using System;

namespace CommandAPI.Dtos
{
	public class CommandReadDto
	{
		public int ID { get; set; }
		
		public string CommandLine { get; set; }
		
		public string HowTo { get; set; }
		
		//public string Platform { get; set; }
	}
}