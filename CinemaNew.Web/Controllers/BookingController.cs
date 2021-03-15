using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaNew.Logic.Managers;
using CinemaNew.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaNew.Web.Controllers
{
    public class BookingController : Controller
    {
        private MovieManager movie = new MovieManager();
        private CategoryManager category = new CategoryManager();
        private BookingManager booking = new BookingManager();

        //public IActionResult Create()
        //{
        //   BookingModel model = new BookingModel();

        //    return View(model);
        //}
        public IActionResult MyMovies()
        {
            var bookings = booking.GetUserBookings();

            return View(bookings);
        }

        public IActionResult Create(BookingModel model)
        {

            if (ModelState.IsValid)
            {
                var result = booking.CreateBooking(model.Name);
                if (String.IsNullOrEmpty(result))
                {
                    return RedirectToAction("Category", "Movies");
                }
                else
                {
                    ModelState.AddModelError("validation", result);
                }
            }

            return View(model);
        }



        public IActionResult Cancel(string name)
        {
            booking.CancelBooking(name);


            return RedirectToAction(nameof(MyMovies));
        }
    }
}
