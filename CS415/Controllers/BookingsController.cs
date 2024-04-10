using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CS415.Data;
using CS415.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CS415.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CheckIn,CheckOut,RoomId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Adjust as needed
            }
            return View(booking);
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings.Include(b => b.Room).ToListAsync();
            return View(bookings);
        }

  
    }
}
