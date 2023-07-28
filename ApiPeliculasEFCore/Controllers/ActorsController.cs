using ApiPeliculasEFCore.DTOs;
using ApiPeliculasEFCore.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
	[ApiController]
	[Route("api/actors")]
	public class ActorsController: ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
			this.context = context;
			this.mapper = mapper;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Actor>>> Get()
		{
			return await context.Actors.ToListAsync();
		}

		
		[HttpGet("idname")]
		public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdName()
		{
			return await context.Actors.Select( actor => new ActorDTO { Id = actor.Id, Name = actor.Name} ).ToListAsync();
		}


		[HttpGet("name/exactly")]
		public async Task<ActionResult<IEnumerable<ActorDTO>>> Get(string name)
		{
			//Version 1
			return await context.Actors.ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
		}
		

		[HttpGet("name/contains")]
		public async Task<ActionResult<IEnumerable<Actor>>> GetContains(string name)
		{
			//Version 2: Contains
			return await context.Actors.Where( actor => actor.Name.Contains(name)).ToListAsync();
		}


		[HttpGet("birthdate/range")]
		public async Task<ActionResult<IEnumerable<Actor>>> Get(DateTime init, DateTime end)
		{
			return await context.Actors.Where( actor => actor.Birthdate >= init && actor.Birthdate <= end).ToListAsync();
		}


		[HttpGet("{id:int}")]
		public async Task<ActionResult<Actor>> Get(int id)
		{
			var actor = await context.Actors.FirstOrDefaultAsync( actor => actor.Id == id);

			if (actor is null)
			{
				return NotFound();
			}

			return actor;
		}


		[HttpPost]
		public async Task<ActionResult> Post(ActorCreationDTO actorCreationDTO)
		{
			var thereIsAlreadyActorWithThisName = await context.Genres.AnyAsync(g => g.Name == actorCreationDTO.Name);

			if (thereIsAlreadyActorWithThisName)
			{
				return BadRequest("There is already an actor with the name " + actorCreationDTO.Name);
			}
			var actor = mapper.Map<Actor>(actorCreationDTO);
			context.Add(actor);
			await context.SaveChangesAsync();
			return Ok();
		}


		[HttpPut("{id:int}")]
		public async Task<ActionResult> Put(int id, ActorCreationDTO actorCreationDTO)
		{
			var actor = mapper.Map<Actor>(actorCreationDTO);
			actor.Id = id;
			context.Update(actor);
			await context.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult> Delete(int id)
		{
			var deletedRows = await context.Actors.Where(a => a.Id == id).ExecuteDeleteAsync();

			if (deletedRows == 0)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}
