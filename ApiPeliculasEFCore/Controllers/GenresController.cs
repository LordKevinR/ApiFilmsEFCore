using ApiPeliculasEFCore.DTOs;
using ApiPeliculasEFCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
	[ApiController]
	[Route("api/genres")]
	public class GenresController: ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public GenresController(ApplicationDbContext context, IMapper mapper)
        {
			this.context = context;
			this.mapper = mapper;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Genre>>> Get()
		{
			return await context.Genres.ToListAsync();
		}


		[HttpPost]
		public async Task<ActionResult> Post(GenreCreationDTO genreCreation)
		{
			var thereIsAlreadyGenreWithThisName = await context.Genres.AnyAsync(g => g.Name == genreCreation.Name);

			if (thereIsAlreadyGenreWithThisName)
			{
				return BadRequest("There is already a genre with the name " + genreCreation.Name);
			}

			var genre = mapper.Map<Genre>(genreCreation);

			context.Add(genre);
			await context.SaveChangesAsync();
			return Ok();
		}


		[HttpPost("several")]
		public async Task<ActionResult> Post(GenreCreationDTO[] genreCreationDTO)
		{
			var genres = mapper.Map<Genre[]>(genreCreationDTO);

			context.AddRange(genres);
			await context.SaveChangesAsync();
			return Ok();
		}


		[HttpPut("{id:int}/name2")]
		public async Task<ActionResult> Put(int id)
		{
			var genres = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

			if (genres is null)
			{
				return NotFound();
			}

			genres.Name = genres.Name + "2";

			await context.SaveChangesAsync();
			return Ok();
		}


		[HttpPut("{id:int}")]
		public async Task<ActionResult> Put(int id, GenreCreationDTO genreCreationDTO)
		{
			var genre = mapper.Map<Genre>(genreCreationDTO);
			genre.Id = id;
			context.Update(genre);
			await context.SaveChangesAsync();
			return Ok();
		}


		[HttpDelete("{id:int}")]
		public async Task<ActionResult> Delete(int id)
		{
			var deletedRows = await context.Genres.Where(g => g.Id == id).ExecuteDeleteAsync();

			if (deletedRows == 0)
			{
				return NotFound();
			}

			return NoContent();
		}


		[HttpDelete("{id:int}/before")]
		public async Task<ActionResult> DeleteOld(int id)
		{
			var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

			if (genre is null)
			{
				return NotFound();
			}

			context.Remove(genre);
			await context.SaveChangesAsync();
			return NoContent();
		}
	}
}
