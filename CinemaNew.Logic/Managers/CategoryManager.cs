using CinemaNew.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaNew.Logic.Managers
{
    public class CategoryManager
    {
        public List<Category> GetAllCategories()
        {
            using (var db = new CinemaNewDB())
            {
                return db.Category.OrderBy(c => c.Name).ToList();
            }
        }
        public Category GetCategory(int id)
        {
            using (var db = new CinemaNewDB())
            {
                return db.Category.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
