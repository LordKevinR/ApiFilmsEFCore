using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ApiPeliculasEFCore.Entities.Configs
{
	public class ActorConfig : IEntityTypeConfiguration<Actor>
	{
		public void Configure(EntityTypeBuilder<Actor> builder)
		{
			builder.Property(a => a.Birthdate).HasColumnType("date");
			builder.Property(a => a.Fortune).HasPrecision(18, 2);

		}
	}
}
