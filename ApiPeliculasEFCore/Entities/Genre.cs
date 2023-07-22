using System.ComponentModel.DataAnnotations;

namespace ApiPeliculasEFCore.Entities
{
	public class Genre
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public HashSet<Film> films { get; set; } = new HashSet<Film>();
    }
}




// [StringLength(maximumLength: 150)] esta es la forma de anotaciones de datos para que el maximo sea de 150 caracteres
// [Key] se utiliza esta DataAnnotation para que esa propiedad sea reconocida como una 
// llave primaria en la migracion, en este caso no es necesario, porque es automatico cuando la propiedad se llama Id
