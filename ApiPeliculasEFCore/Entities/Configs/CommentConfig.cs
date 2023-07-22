using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ApiPeliculasEFCore.Entities.Configs
{
	public class CommentConfig : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.Property(c => c.Content).HasMaxLength(500);
		}
	}
}
