using CorePeliculasNCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasNCM.Repositories
{
    public interface IRepository
    {
        List<Genero> GetGeneros();

        List<Pelicula> GetPeliculasGenero(int idgenero);

        Pelicula GetPeliculaId(int idpelicula);

        List<Pelicula> GetPeliculasSession(List<int> idpeliculas);

        void EditarPelicula(int idpelicula, int precio, String foto);
    }
}
