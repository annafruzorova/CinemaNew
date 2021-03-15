using CinemaNew.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaNew.Logic.Managers
{
    public class MovieManager
    {
        public List<Movies> GetAllMovies()
        {

            using (var db = new CinemaNewDB())
            {
                return db.Movies.OrderBy(m => m.Name).ToList();
            }
        }
        public Movies GetMovies(int id)
        {
            using (var db = new CinemaNewDB())
            {
                return db.Movies.FirstOrDefault(m => m.Id == id);
            }
        }
        public List<Movies> GetByCategory(int categoryId)
        {
            using (var db = new CinemaNewDB())
            {
                return db.Movies
                    
                    .Where(m => m.CategoryId == categoryId)
                    .OrderByDescending(m => m.Name)
                    .ToList();
            }
        }

       
    }
}
