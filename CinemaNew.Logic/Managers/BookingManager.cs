using CinemaNew.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaNew.Logic.Managers
{
    public class BookingManager
    {
        public List<UserBookings> GetUserBookings()
        {

            using (var db = new CinemaNewDB())
            {
                return db.UserBookings.OrderBy(b => b.Name).ToList();
            }
        }
        public UserBookings CancelBooking(string name)
        {
            using (var db = new CinemaNewDB())
            {
                var booking = db.UserBookings.FirstOrDefault(b => b.Name.ToLower() == name.ToLower());
                if (booking != null)
                {
                    db.UserBookings.Remove(booking);

                    db.SaveChanges();

                    return booking;
                }
            }

            return null;
        }
        public string CreateBooking(string name)
        {
            using (var db = new CinemaNewDB())
            {
                db.UserBookings.Add(new UserBookings()
                {
                    Name = name,

                });

                db.SaveChanges();

            }
            return null;
        }

    }
}
