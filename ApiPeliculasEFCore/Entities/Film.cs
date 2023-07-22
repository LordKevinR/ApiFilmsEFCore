namespace ApiPeliculasEFCore.Entities
{
	public class Film
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
        public bool InTheaters { get; set; }
        public DateTime ReleaseDate { get; set; }
		public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>(); //Esto es para indicar que la relacion es de muchos comentarios
        public HashSet<Genre> Genres { get; set; } = new HashSet<Genre>();
		public List<FilmActor> FilmsActors { get; set; } = new List<FilmActor>();

    }
}
