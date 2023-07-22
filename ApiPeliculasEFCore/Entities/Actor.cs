namespace ApiPeliculasEFCore.Entities
{
	public class Actor
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Fortune { get; set; }
        public DateTime Birthdate { get; set; }

    }
}
