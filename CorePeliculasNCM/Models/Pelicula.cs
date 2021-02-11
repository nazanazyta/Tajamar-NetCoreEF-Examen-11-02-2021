using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasNCM.Models
{
    [Table("peliculas")]
    public class Pelicula
    {
        [Key]
        [Column("idpelicula")]
        public int IdPelicula { get; set; }
        [Column("idgenero")]
        public int IdGenero { get; set; }
        [Column("titulo")]
        public String Titulo { get; set; }
        [Column("argumento")]
        public String Argumento { get; set; }
        [Column("foto")]
        public String Foto { get; set; }
        [Column("precio")]
        public int Precio { get; set; }
    }
}
