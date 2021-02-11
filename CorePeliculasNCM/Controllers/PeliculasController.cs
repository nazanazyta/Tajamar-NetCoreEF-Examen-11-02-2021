using CorePeliculasNCM.Repositories;
using Microsoft.AspNetCore.Mvc;
using CorePeliculasNCM.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePeliculasNCM.Models;
using Microsoft.AspNetCore.Http;
using CorePeliculasNCM.Helpers;

namespace CorePeliculasNCM.Controllers
{
    public class PeliculasController : Controller
    {
        IRepository repo;
        UploadService UploadService;

        public PeliculasController(IRepository repo, UploadService uploadservice)
        {
            this.repo = repo;
            this.UploadService = uploadservice;
        }

        public IActionResult Lista(int idgenero)
        {
            return View(this.repo.GetPeliculasGenero(idgenero));
        }

        public IActionResult Details(int idpelicula)
        {
            return View(this.repo.GetPeliculaId(idpelicula));
        }

        public IActionResult GuardarPelicula(int idpelicula)
        {
            List<int> peliculassession;
            int total;
            if (HttpContext.Session.GetObject<List<int>>("peliculas") == null)
            {
                peliculassession = new List<int>();
                total = 0;
            }
            else
            {
                peliculassession = HttpContext.Session.GetObject<List<int>>("peliculas");
                total = HttpContext.Session.GetObject<int>("total");
            }
            if (peliculassession.Contains(idpelicula) == false)
            {
                peliculassession.Add(idpelicula);
                HttpContext.Session.SetObject("peliculas", peliculassession);
                Pelicula p = this.repo.GetPeliculaId(idpelicula);
                total += p.Precio;
                HttpContext.Session.SetObject("total", total);
            }
            return View("Details", this.repo.GetPeliculaId(idpelicula));
        }

        public IActionResult MostrarPeliculas(int? idpelicula)
        {
            List<int> peliculassession = HttpContext.Session.GetObject<List<int>>("peliculas");
            int total = HttpContext.Session.GetObject<int>("total");
            if (peliculassession == null)
            {
                return View();
            }
            else
            {
                if (idpelicula != null)
                {
                    peliculassession.Remove(idpelicula.Value);
                    HttpContext.Session.SetObject("peliculas", peliculassession);
                    Pelicula p = this.repo.GetPeliculaId(idpelicula.Value);
                    total -= p.Precio;
                    HttpContext.Session.SetObject("total", total);
                }
                List<Pelicula> peliculas = this.repo.GetPeliculasSession(peliculassession);
                return View(peliculas);
            }
        }

        [HttpPost]
        public IActionResult MostrarPeliculas()
        {
            List<int> peliculassession = HttpContext.Session.GetObject<List<int>>("peliculas");
            List<Pelicula> peliculas = this.repo.GetPeliculasSession(peliculassession);
            TempData.SetObject("peliculas", peliculas);
            return RedirectToAction("Carrito");
        }

        public IActionResult Carrito()
        {
            List<Pelicula> peliculas = TempData.GetObject<List<Pelicula>>("peliculas");
            return View(peliculas);
        }

        public IActionResult Edit(int idpelicula)
        {
            return View(this.repo.GetPeliculaId(idpelicula));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile fichero, Pelicula pelicula)
        {
            if (fichero != null)
            {
                await this.UploadService.UploadFileAsync(fichero, Folders.Images);
            }
            this.repo.EditarPelicula(pelicula.IdPelicula, pelicula.Precio, fichero.FileName);
            ViewData["mensaje"] = "Cambios guardados";
            return RedirectToAction("Details", this.repo.GetPeliculaId(pelicula.IdPelicula));
        }
    }
}
