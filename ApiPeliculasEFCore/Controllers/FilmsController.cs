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

		[HttpPost]
		public async Task<ActionResult> Post(FilmCreationDTO filmCreationDTO)
		{
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
    }
}
