using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ApiPeliculasEFCore.Entities.Configs
{
	public class FilmConfig : IEntityTypeConfiguration<Film>
	{
		public void Configure(EntityTypeBuilder<Film> builder)
		{
			builder.Property(f => f.ReleaseDate).HasColumnType("date");
		}
	}
}
