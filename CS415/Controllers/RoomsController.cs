using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CS415.Data; // Use the correct namespace where ApplicationDbContext is located
using CS415.Models; // Ensure this matches the namespace of your Room model
using System.Threading.Tasks;

public class RoomsController : Controller
{
    private readonly ApplicationDbContext _context;

    public RoomsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Rooms
    public async Task<IActionResult> Index()
    {
        var rooms = await _context.Rooms.ToListAsync();
        return View(rooms);
    }

    // GET: Rooms/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var room = await _context.Rooms
            .FirstOrDefaultAsync(m => m.RoomId == id);
        if (room == null)
        {
            return NotFound();
        }

        return View(room);
    }

    // Additional CRUD operations can be added here as needed.
}
