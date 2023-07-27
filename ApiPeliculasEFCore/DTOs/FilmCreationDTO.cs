namespace ApiPeliculasEFCore.DTOs
{
	public class FilmCreationDTO
	{
		public string Title { get; set; } = null!;
		public bool InTheaters { get; set; }
		public DateTime ReleaseDate { get; set; }
		public List<int> Genres { get; set; } = new List<int>();
        public List<FilmActorCreationDTO> FilmsActors { get; set; } = new List<FilmActorCreationDTO>();
    }
}
