using CinemaNew.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaNew.Web.Models
{
    public class CategoryModel
    {
        public List<Category> Category { get; set; }

        public List<Movies> Movies { get; set; }

        public List<UserBookings> UserBookings { get; set; }

        public Category ActiveCategory { get; set; }

    }
}
