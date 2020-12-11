using System;
using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Dtos
{
	public class CommandCreateDto
	{
		[Required]
		[MaxLength(250)]
		public string CommandLine { get; set; }
		
		[Required]
		public string HowTo { get; set; }
		
		[Required]
		public string Platform { get; set; }
	}
}