using CorePeliculasNCM.Data;
using CorePeliculasNCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasNCM.Repositories
{
    public class RepositorySQL: IRepository
    {
        HospitalContext context;

        public RepositorySQL(HospitalContext context)
        {
            this.context = context;
        }

        public List<Genero> GetGeneros()
        {
            return this.context.Generos.ToList();
        }

        public List<Pelicula> GetPeliculasGenero(int idgenero)
        {
            return this.context.Peliculas.Where(z => z.IdGenero == idgenero).ToList();
        }

        public Pelicula GetPeliculaId(int idpelicula)
        {
            return this.context.Peliculas.SingleOrDefault(z => z.IdPelicula == idpelicula);
        }

        public List<Pelicula> GetPeliculasSession(List<int> idpeliculas)
        {
            var consulta = from datos in this.context.Peliculas
                           where idpeliculas.Contains(datos.IdPelicula)
                           select datos;
            return consulta.ToList();
        }

        public void EditarPelicula(int idpelicula, int precio, String foto)
        {
            Pelicula pel = this.GetPeliculaId(idpelicula);
            pel.Foto = foto;
            pel.Precio = precio;
            this.context.SaveChanges();
        }
    }
}
