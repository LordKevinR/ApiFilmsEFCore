namespace ApiPeliculasEFCore.Entities
{
	public class Film
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
        public bool InTheaters { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
