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
	}
}
