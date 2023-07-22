using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entities.Configs
{
	public class FilmActorConfig : IEntityTypeConfiguration<FilmActor>
	{
		public void Configure(EntityTypeBuilder<FilmActor> builder)
		{
			builder.HasKey(pa => new { pa.ActorId, pa.FilmId} );
		}
	}
}
