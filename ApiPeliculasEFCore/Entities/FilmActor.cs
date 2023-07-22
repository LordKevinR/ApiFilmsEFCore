﻿namespace ApiPeliculasEFCore.Entities
{
	public class FilmActor
	{
        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;
        public string Character { get; set; } = null!;
        public int Order { get; set; }
    }
}
