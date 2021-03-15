using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaNew.Web.Models;
using CinemaNew.Logic.Managers;

namespace CinemaNew.Web.Controllers
{
    public class HomeController : Controller
    {
        private CategoryManager category = new CategoryManager();
        public IActionResult Index()
        {
            var data = category.GetAllCategories();
            return View(data);
        }

    }
}
