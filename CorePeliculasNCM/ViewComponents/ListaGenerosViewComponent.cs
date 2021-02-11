using CorePeliculasNCM.Models;
using CorePeliculasNCM.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasNCM.ViewComponents
{
    public class ListaGenerosViewComponent: ViewComponent
    {
        private IRepository repo;

        public ListaGenerosViewComponent(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = this.repo.GetGeneros();
            return View(generos);
        }
    }
}
