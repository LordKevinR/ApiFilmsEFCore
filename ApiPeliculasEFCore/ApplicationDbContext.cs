using ApiPeliculasEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiPeliculasEFCore
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //aplica las configuraciones que puse en Entities/Config 
		}

		protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
		{
			configurationBuilder.Properties<string>().HaveMaxLength(150);
		}



		public DbSet<Genre> Genres => Set<Genre>();
		public DbSet<Actor> Actors => Set<Actor>();
		public DbSet<Film> Films => Set<Film>();
		public DbSet<Comment> Comments => Set<Comment>();

	}
}
