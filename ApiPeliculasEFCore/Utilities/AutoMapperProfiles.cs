using ApiPeliculasEFCore.DTOs;
using ApiPeliculasEFCore.Entities;
using AutoMapper;

namespace ApiPeliculasEFCore.Utilities
{
	public class AutoMapperProfiles: Profile
	{
        public AutoMapperProfiles()
        {
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<ActorCreationDTO, Actor>();
            CreateMap<Actor, ActorDTO>();
			CreateMap<CommentCreationDTO, Comment>();

			CreateMap<FilmCreationDTO, Film>()
                .ForMember(ent => ent.Genres, dto => 
                dto.MapFrom(field => field.Genres.Select( id => new Genre { Id = id })));

            CreateMap<FilmActorCreationDTO, FilmActor>();
        }
    }
}
