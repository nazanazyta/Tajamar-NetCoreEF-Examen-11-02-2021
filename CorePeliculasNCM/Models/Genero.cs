using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasNCM.Models
{
    [Table("generos")]
    public class Genero
    {
        [Key]
        [Column("idgenero")]
        public int IdGenero { get; set; }
        [Column("genero")]
        public String Nombre { get; set; }
    }
}
