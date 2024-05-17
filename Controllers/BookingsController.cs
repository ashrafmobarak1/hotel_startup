using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel_startup.Data;
using hotel_startup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hotel_startup.Controllers
{
    public class BookingsController : Controller
    {
        private readonly hotel_startupDBcontext _dbcontext;
        public IEnumerable<SelectListItem> CitySelectList { get; set; }
        
        public BookingsController(hotel_startupDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            // ViewData["City"] = _dbcontext.Bookings.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            //ViewData["City"] = _dbcontext.City.Select(c => new City
            //{
            //    Id = c.Id,
            //    Name = c.Name
            //});
            // CitySelectList = city;
            ////////// extendedCity extCity = new extendedCity(_dbcontext);
            /////////CitySelectList = extCity.getCityList().Select(t => new SelectListItem { Text = t.Name, Value = t.Id }); 
            //CitySelectList = extCity.getCities();//.Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() });
            // var c =extCity. getCities();
            //////// ViewBag.City = CitySelectList;
            ///
            var _cityList = new SelectList(_dbcontext.City.ToList(), "Id", "Name");
            var _roomTypeList = new SelectList(_dbcontext.RoomType.ToList(), "Id", "Name");
            ViewBag.City = _cityList;
            ViewBag.RoomType = _roomTypeList;
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(Booking booking)
        {
            Booking book = new Booking()
            {
                Name = booking.Name,
                mobile = booking.mobile,
                startDate=booking.startDate,
                endDate=booking.endDate,
                personNo=booking.personNo,
                cityId=booking.cityId,
                roomTypeId=booking.roomTypeId,
                _guid=Guid.NewGuid(),
            };
            await _dbcontext.Bookings.AddAsync(book);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var books= await _dbcontext.Bookings
                .Include(c=>c.City)
                .Include(s=>s.RoomType)
                .ToListAsync();
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> View(Int64 id)
        {
            var fromDatabaseEF = new SelectList(_dbcontext.City.ToList(), "Id", "Name");
            ViewBag.City = fromDatabaseEF;
            var books = await _dbcontext.Bookings.FirstOrDefaultAsync(x=>x.Id==id);

            if (books != null)
            {
                Booking viewbooking = new Booking()
                {
                    Id = books.Id,
                    Name = books.Name,
                    mobile = books.mobile,
                    startDate = books.startDate,
                    endDate = books.endDate,
                    personNo = books.personNo,
                    cityId = books.cityId,
                    roomTypeId = books.roomTypeId,
                    modifiedDate = DateTime.Now,

                };
                return await Task.Run(()=> View("View",viewbooking));
            }
            else
            {
                return RedirectToAction("Index");
            }
           
           //
        }

        [HttpPost]
        public async Task<IActionResult> View(Booking booking)
        {
            var books = await _dbcontext.Bookings.FindAsync(booking.Id);

            if (books != null)
            {
                books.Id = booking.Id;
                books.Name = booking.Name;
                books.mobile = booking.mobile;
                books.startDate = booking.startDate;
                books.endDate = booking.endDate;
                books.personNo = booking.personNo;
                books.cityId = booking.cityId;
                books.roomTypeId = booking.roomTypeId;
                books.modifiedDate = DateTime.Now;

                await _dbcontext.SaveChangesAsync();
               
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

            //
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Booking booking)
        {
            var books = await _dbcontext.Bookings.FindAsync(booking.Id);

            if (books != null)
            {
               

                 _dbcontext.Bookings.Remove(books);
                await _dbcontext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

            //
        }
    }
}
