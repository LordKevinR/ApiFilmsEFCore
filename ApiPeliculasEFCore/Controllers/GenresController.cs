using ApiPeliculasEFCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiPeliculasEFCore.Controllers
{
	[ApiController]
	[Route("api/genres")]
	public class GenresController: ControllerBase
	{
		private readonly ApplicationDbContext context;

		public GenresController(ApplicationDbContext context)
        {
			this.context = context;
		}

		[HttpPost]
		public async Task<ActionResult> Post(Genre genre)
		{
			context.Add(genre);
			await context.SaveChangesAsync();
			return Ok();
		}
    }
}
