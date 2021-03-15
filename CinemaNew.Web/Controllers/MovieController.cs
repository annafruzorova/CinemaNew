using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaNew.Logic.Managers;
using CinemaNew.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaNew.Web.Controllers
{
    public class MovieController : Controller
    {
        private MovieManager movie = new MovieManager();
        private CategoryManager category = new CategoryManager();
       
            public IActionResult Movie (int? id)
            {
                MoviesModel model = new MoviesModel();
                model.Movies = movie.GetAllMovies();
                if (id.HasValue)
                {

                    model.ActiveMovies = movie.GetMovies(id.Value);

                    model.Movies = movie.GetByCategory(id.Value);
                }

                return View(model);
            }

        public IActionResult Movie ()
        {
            var data = movie.GetAllMovies();
            return View(data);
        }

        public IActionResult Create(string name)
        {
            movie.CreateBooking(name);

            return RedirectToAction(nameof(Movie));
        }

    }
    }

