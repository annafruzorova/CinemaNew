using CinemaNew.Logic.Managers;
using System;

namespace CinemaNew.Console
{
    class Program
    {
        private static BookingManager booking = new BookingManager();
        private static CategoryManager category = new CategoryManager();
        private static MovieManager movie = new MovieManager();
        static void Main(string[] args)
        {
            System.Console.WriteLine("Categories: ");
            category.GetAllCategories().ForEach(c =>
            {
                System.Console.WriteLine(c.Name);
            });


            System.Console.WriteLine("Movies: ");
            movie.GetAllMovies().ForEach(m =>
            {
                System.Console.WriteLine(m.Name, m.CategoryId, m.AvailableTime);
            });


            while (true)
            {
                System.Console.Write("Enter movies's name (or stop): ");
                string input = System.Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                var movies = movie.CreateBooking(input);
                if (movies != null)
                {
                    System.Console.WriteLine($"Now you have a booking on {movies.Name} at {movies.AvailableTime}");
                }
                else
                {

                    System.Console.WriteLine("Movie is not available!");
                }
            }



            System.Console.WriteLine("Bookings: ");
            booking.GetUserBookings().ForEach(b =>
            {
                System.Console.WriteLine(b.Name, b.Category, b.AvailableTime);
            });



            System.Console.WriteLine("Would you like to cancel this booking?");
            while (true)
            {
                System.Console.Write("Enter movies's name (or stop): ");
                string input = System.Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                var bookings = booking.CancelBooking(input);
                if (bookings != null)
                {
                    System.Console.WriteLine($"Movie {bookings.Name} was succesfully cancel");
                }
                else
                {

                    System.Console.WriteLine("You don't have this bookïng!");
                }
            }
        }
    }
    }

