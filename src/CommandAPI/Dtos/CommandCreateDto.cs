using System;
using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Dtos
{
	public class CommandCreateDto
	{
		[Required]
		public string CommandLine { get; set; }
		
		[Required]
		[MaxLength(250)]
		public string HowTo { get; set; }
		
		[Required]
		public string Platform { get; set; }
	}
}