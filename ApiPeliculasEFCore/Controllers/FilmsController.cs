using ApiPeliculasEFCore.DTOs;
using ApiPeliculasEFCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
	[ApiController]
	[Route("api/films")]
	public class FilmsController: ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public FilmsController(ApplicationDbContext context, IMapper mapper )
        {
			this.context = context;
			this.mapper = mapper;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Film>>> Get()
		{
			return await context.Films.ToListAsync();
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Film>> Get(int id)
		{
			var film = await context.Films
				.Include(f => f.Comments)
				.Include(f => f.Genres)
				.Include(f => f.FilmsActors.OrderBy(fa => fa.Order))
					.ThenInclude(fa =>  fa.Actor)
				.FirstOrDefaultAsync(f => f.Id == id);

			if (film is null)
			{
				return NotFound();
			}

			return film;
		}
		
		[HttpGet("select/{id:int}")]
		public async Task<ActionResult> GetSelect(int id)
		{
			var film = await context.Films
				.Select(film => new
				{
					film.Id,
					film.Title,
					Genres = film.Genres.Select(gen => gen.Name).ToList(),
					Actors = film.FilmsActors.OrderBy(fa => fa.Order).Select(fa =>
					new
					{
						Id = fa.ActorId,
						fa.Actor.Name,
						fa.Character
					}),
					numberOfComments = film.Comments.Count()
				})
				.FirstOrDefaultAsync(f => f.Id == id);

			if (film is null)
			{
				return NotFound();
			}

			return Ok(film);
		}

		[HttpPost]
		public async Task<ActionResult> Post(FilmCreationDTO filmCreationDTO)
		{

			var thereIsAlreadyFilmWithThisName = await context.Films.AnyAsync(f => f.Title == filmCreationDTO.Title);

			if (thereIsAlreadyFilmWithThisName)
			{
				return BadRequest("There is already a film with the name " + filmCreationDTO.Title);
			}


			var film = mapper.Map<Film>(filmCreationDTO);

			if (film.Genres is not null)
			{
				foreach (var genre in film.Genres)
				{
					context.Entry(genre).State = EntityState.Unchanged;
				}
			}

			if (film.FilmsActors is not null)
			{
				for (int i = 0; i < film.FilmsActors.Count; i++)
				{
					film.FilmsActors[i].Order = i + 1;
				}
			}

			context.Add(film);
			await context.SaveChangesAsync();
			return Ok();
		}


		[HttpPut("{id:int}")]
		public async Task<ActionResult> Put(int id, FilmCreationDTO filmCreationDTO)
		{
			var film = mapper.Map<Film>(filmCreationDTO);
			film.Id = id;
			context.Update(film);
			await context.SaveChangesAsync();
			return Ok();
		}


		[HttpDelete("{id:int}")]
		public async Task<ActionResult> Delete(int id)
		{
			var deletedRows = await context.Films.Where(f => f.Id == id).ExecuteDeleteAsync();

			if (deletedRows == 0)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}
