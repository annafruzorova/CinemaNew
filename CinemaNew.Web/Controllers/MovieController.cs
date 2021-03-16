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
        private BookingManager booking = new BookingManager();

        public IActionResult AllMovie(int? id)
        {
            var allMovies = new MoviesModel()
            {
                Category = category.GetAllCategories()
            };

            if (id.HasValue)
            {
                allMovies.ActiveCategory = category.GetCategory(id.Value);
                allMovies.Movies = movie.GetByCategory(id.Value);
            }
            else
            {
                allMovies.Movies = movie.GetAllMovies();
            };

            return View(allMovies);
        }

        public IActionResult Movie()
        {
            var data = movie.GetAllMovies();
            return View(data);
        }

        public IActionResult Category(int? id)
        {
            CategoryModel model = new CategoryModel();
            model.Category = category.GetAllCategories();
            if (id.HasValue)
            {
                
                model.ActiveCategory = category.GetCategory(id.Value);
                
                model.Movies = movie.GetByCategory(id.Value);
            }

            return View(model);
        }

        public IActionResult Movie (int? id)
        {
            MoviesModel model = new MoviesModel();

            if (id.HasValue)
            {
                
                model.Movie = movie.GetMovies(id.Value);
                model.Category = category.GetAllCategories();
                
                model.MovieCategory = category.GetCategory(model.Movie.CategoryId);
                
            }

            return View(model);
        }

    }
}

