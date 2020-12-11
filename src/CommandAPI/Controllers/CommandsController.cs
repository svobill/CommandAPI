using System;
using System.Collections.Generic;
using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class CommandsController : ControllerBase
    {
		private readonly ICommandAPIRepo _repository;
		private readonly IMapper _mapper;
		
		public CommandsController(ICommandAPIRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		
		[HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
			var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
		
		[HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandByID(int id)
        {
			var commandItem = _repository.GetCommandByID(id);
			
			if (commandItem == null)
			{
				return NotFound();
			}
			
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
    }
}