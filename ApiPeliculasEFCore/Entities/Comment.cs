namespace ApiPeliculasEFCore.Entities
{
	public class Comment
	{
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool Recommend { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;
    }
}
