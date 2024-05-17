using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotel_startup.Data;
using hotel_startup.Models;

namespace hotel_startup.Controllers
{
    public class CitiesController : Controller
    {
        private readonly hotel_startupDBcontext _context;

        public CitiesController(hotel_startupDBcontext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.City.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,createdDate,modifiedDate")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,createdDate,modifiedDate")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var city = await _context.City.FindAsync(id);
            _context.City.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        private bool CityExists(long id)
        {
            return _context.City.Any(e => e.Id == id);
        }
    }
    public class extendedCity 
    {
        private readonly hotel_startupDBcontext _db;
        public extendedCity(hotel_startupDBcontext context)
        {
            _db = context;
        }
        public List<City> getCities()
        {
            try
            {


                string qry = $"select Id,Name from City";
                ///////////////////hdsjhdsgd]
                ///
                var result = _db.City.Select(c => new City
                {
                    Id = c.Id,
                    Name = c.Name
                }); ;
                //var result = _db.City.FromSqlRaw(qry).ToList();
                ////////////////////////



                if (result != null)
                {
                    return result.ToList(); ;
                }
                else //if(result !=null)
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                return null;
            }



        }

        public  IEnumerable<DropDownListModel> getCityList()
        {
            string sql = $"select * from City";
             var result =  _db.City.FromSqlRaw(sql);
            return (IEnumerable<DropDownListModel>)result;
            //return result.ToList();
        }
    }

    public class DropDownListModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
    }
}
