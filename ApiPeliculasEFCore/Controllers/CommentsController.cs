using ApiPeliculasEFCore.DTOs;
using ApiPeliculasEFCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiPeliculasEFCore.Controllers
{
	[ApiController]
	[Route("api/films/{filmId:int}/comments")]
	public class CommentsController: ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public CommentsController(ApplicationDbContext context, IMapper mapper)
        {
			this.context = context;
			this.mapper = mapper;
		}

		[HttpPost]
		public async Task<ActionResult> post(int filmId, CommentCreationDTO commentCreationDTO)
		{
			var comment = mapper.Map<Comment>(commentCreationDTO);
			comment.FilmId = filmId;
			context.Add(comment);
			await context.SaveChangesAsync();
			return Ok();
		}
    }
}
