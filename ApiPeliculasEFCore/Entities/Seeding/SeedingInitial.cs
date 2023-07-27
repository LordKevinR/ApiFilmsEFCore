using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Entities.Seeding
{
	public class SeedingInitial
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			var samuelLJackson = new Actor()
			{
				Id = 2,
				Name = "Samuel L. Jackson",
				Birthdate = new DateTime(1948, 12, 21),
				Fortune = 15000
			};
			var robertDowneyJunior = new Actor()
			{
				Id = 3,
				Name = "Robert Downey Jr.",
				Birthdate = new DateTime(1965, 4, 4),
				Fortune = 18000
			};
			modelBuilder.Entity<Actor>().HasData(samuelLJackson, robertDowneyJunior);


			var avengers = new Film()
			{
				Id = 2,
				Title = "Avengers EndGame",
				ReleaseDate = new DateTime(2019, 4, 22)
			};			
			var spidermanNWH = new Film()
			{
				Id = 3,
				Title = "Spider-Man: No Way Home",
				ReleaseDate = new DateTime(2021, 12, 13)
			};			
			var spiderManSpiderVerse2 = new Film()
			{
				Id = 4,
				Title = "Spider-Man: Across the Spider-Verse (Part One)",
				ReleaseDate = new DateTime(2022, 10, 7)
			};
			modelBuilder.Entity<Film>().HasData(avengers, spidermanNWH, spiderManSpiderVerse2);


			var commentAvengers = new Comment()
			{
				Id = 2,
				Recommend = true,
				Content = "I Love it",
				FilmId = avengers.Id
			};		
			var commentAvengers2 = new Comment()
			{
				Id = 3,
				Recommend = true,
				Content = "A very good film",
				FilmId = avengers.Id
			};			
			var commentNWH = new Comment()
			{
				Id = 4,
				Recommend = false,
				Content = "I dont really like it",
				FilmId = spidermanNWH.Id
			};
			modelBuilder.Entity<Comment>().HasData(commentAvengers, commentAvengers2, commentNWH);



			var tableGenreFilm = "FilmGenre";
			var genreIdProperty = "GenresId";
			var filmIdProperty = "filmsId";

			var scienceFiction = 5;
			var animation = 6;


			// muchos a muchos con salto ( esto es mas avanzado )

			modelBuilder.Entity(tableGenreFilm).HasData(
					new Dictionary<string, object>
					{
						[genreIdProperty] = scienceFiction,
						[filmIdProperty] = avengers.Id
					},

					new Dictionary<string, object>
					{
						[genreIdProperty] = scienceFiction,
						[filmIdProperty] = spidermanNWH.Id
					},

					new Dictionary<string, object>
					{
						[genreIdProperty] = animation,
						[filmIdProperty] = spiderManSpiderVerse2.Id
					}
				);


			// muchos a muchos sin saltos 

			var samuelLJacksonSpiderMAnNWH = new FilmActor
			{
				ActorId = samuelLJackson.Id,
				FilmId = spidermanNWH.Id,
				Order = 1,
				Character = "Nick Fury"
			};			
			var samuelLJacksonAvenger = new FilmActor
			{
				ActorId = samuelLJackson.Id,
				FilmId = avengers.Id,
				Order = 2,
				Character = "Nick Fury"
			};			
			var robertDowneyJuniorAvengers = new FilmActor
			{
				ActorId = robertDowneyJunior.Id,
				FilmId = avengers.Id,
				Order = 1,
				Character = "Iron Man"
			};
			modelBuilder.Entity<FilmActor>().HasData(samuelLJacksonSpiderMAnNWH, samuelLJacksonAvenger, robertDowneyJuniorAvengers);


		}
	}
}
