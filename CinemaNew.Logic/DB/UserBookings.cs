﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaNew.Logic.DB
{
    public partial class UserBookings
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public TimeSpan AvailableTime { get; set; }
        public int CategoryId { get; set; }
        public int MoviesId { get; set; }
    }
}
