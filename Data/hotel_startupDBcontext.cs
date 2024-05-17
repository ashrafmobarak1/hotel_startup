using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel_startup.Models;
using Microsoft.EntityFrameworkCore;

namespace hotel_startup.Data
{
    public class hotel_startupDBcontext : DbContext
    {
        public hotel_startupDBcontext( DbContextOptions options) : base(options)
        {
        }

        public  DbSet<Booking> Bookings { get; set; }

        public DbSet<hotel_startup.Models.City> City { get; set; }

        public DbSet<hotel_startup.Models.RoomType> RoomType { get; set; }
    }
}
