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
		
		[HttpGet(Name="GetAllCommands")]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
			var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
		
		[HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandByID(int id)
        {
			var commandItem = _repository.GetCommandByID(id);
			
			if (commandItem == null)
			{
				return NotFound();
			}
			
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
		
		[HttpPost]
		public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
		{
			var commandModel = _mapper.Map<Command>(commandCreateDto);
			_repository.CreateCommand(commandModel);
			_repository.SaveChanges();
			
			var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
			
			return CreatedAtRoute(nameof(GetCommandByID), new {ID = commandReadDto.ID}, commandReadDto);	
		}
    }
}