using System.ComponentModel.DataAnnotations;

namespace ApiPeliculasEFCore.DTOs
{
	public class GenreCreationDTO
	{
		[StringLength(maximumLength: 150)]
		public string Name { get; set; } = null!;

    }
}
