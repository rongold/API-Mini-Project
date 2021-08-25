using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACNHApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACNHApi.Controllers
{
	[Route("api/ACNHBugs")]
    [ApiController]
    public class ACNHBugsController : ControllerBase
    {
        private readonly ACNHContext _context;

        public ACNHBugsController(ACNHContext context)
        {
            _context = context;
        }

        // GET: api/VillagerItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugsResponseTDO>>> GetBugItems()
        {
            return await _context.BugItems.Include(i=>i.Name).Include(i=>i.Availability)
                .Select(x => BugItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BugsResponseTDO>> GetBugItem(int id)
        {
            var bugItem = await _context.BugItems.Include(i=>i.Name).Include(i=>i.Availability).Where(i=>i.Id==id).FirstOrDefaultAsync();
            object response =  "Bug not found" ;
            if (bugItem == null)
            {
                return NotFound(response.ToString());
            }

            return BugItemToDTO(bugItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBugItem(int id, BugsResponseTDO acnhItemDTO)
        {
            if (id != acnhItemDTO.Id)
            {
                return BadRequest();
            }

            var bugItem = await _context.BugItems.Include(i => i.Name).Include(i => i.Availability).Where(i => i.Id == id).FirstOrDefaultAsync();
            if (bugItem == null)
            {
                return NotFound();
            }

            bugItem.Id = acnhItemDTO.Id;
            bugItem.Filename = acnhItemDTO.Filename;
            bugItem.Name = new Models.Name
            {
                NameUSen = acnhItemDTO.Name.NameUSen,
                NameEUen = acnhItemDTO.Name.NameEUen,
                NameEUde = acnhItemDTO.Name.NameEUde,
                NameEUes = acnhItemDTO.Name.NameEUes

            };
            bugItem.Availability = new Models.Availability
            {
                Monthnorthern = acnhItemDTO.Availability.Monthnorthern,
                Monthsouthern = acnhItemDTO.Availability.Monthsouthern,
                Time = acnhItemDTO.Availability.Time,
                IsAllDay = acnhItemDTO.Availability.IsAllDay,
                IsAllYear = acnhItemDTO.Availability.IsAllYear,
                Location = acnhItemDTO.Availability.Location,
                Rarity = acnhItemDTO.Availability.Rarity,
                Montharraynorthern = acnhItemDTO.Availability.Montharraynorthern,
                Montharraysouthern = acnhItemDTO.Availability.Montharraysouthern,
                Timearray = acnhItemDTO.Availability.Timearray
            };
            bugItem.Price = bugItem.Price;
            bugItem.Priceflick = bugItem.Priceflick;
            bugItem.Catchphrase = bugItem.Catchphrase;
            bugItem.Museumphrase = bugItem.Museumphrase;
            bugItem.Icon_uri = bugItem.Icon_uri;
            bugItem.Image_uri = bugItem.Image_uri;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!BugItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BugsResponseTDO>> CreateBugItem(BugsResponseTDO acnhBugDTO)
        {
            var bugItem = new BugsResponse
            {
                Id = acnhBugDTO.Id,
                Filename = acnhBugDTO.Filename,
                Name = new Models.Name
                {
                    NameUSen = acnhBugDTO.Name.NameUSen,
                    NameEUen = acnhBugDTO.Name.NameEUen,
                    NameEUde = acnhBugDTO.Name.NameEUde,
                    NameEUes = acnhBugDTO.Name.NameEUes

                },
                Availability = new Models.Availability
                {
                    Monthnorthern = acnhBugDTO.Availability.Monthnorthern,
                    Monthsouthern = acnhBugDTO.Availability.Monthsouthern,
                    Time = acnhBugDTO.Availability.Time,
                    IsAllDay = acnhBugDTO.Availability.IsAllDay,
                    IsAllYear = acnhBugDTO.Availability.IsAllYear,
                    Location = acnhBugDTO.Availability.Location,
                    Rarity = acnhBugDTO.Availability.Rarity,
                    Montharraynorthern = acnhBugDTO.Availability.Montharraynorthern,
                    Montharraysouthern = acnhBugDTO.Availability.Montharraysouthern,
                    Timearray = acnhBugDTO.Availability.Timearray
                },
                Price = acnhBugDTO.Price,
                Priceflick = acnhBugDTO.Priceflick,
                Museumphrase = acnhBugDTO.Museumphrase,
                Catchphrase = acnhBugDTO.Catchphrase,
                Icon_uri = acnhBugDTO.Icon_uri,
            };

            _context.BugItems.Add(bugItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBugItem),
                new { id = bugItem.Id },
                BugItemToDTO(bugItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBugItem(int id)
        {
            var bugItem = await _context.BugItems.Include(i => i.Name).Include(i => i.Availability).Where(i => i.Id == id).FirstOrDefaultAsync();

            if (bugItem == null)
            {
                return NotFound();
            }

            _context.BugItems.Remove(bugItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BugItemExists(long id) =>
             _context.BugItems.Any(e => e.Id == id);

        private static BugsResponseTDO BugItemToDTO(BugsResponse bugItem) =>
            new BugsResponseTDO
            {
                Id = bugItem.Id,
                Filename = bugItem.Filename,
                Name = new Name
                {
                    NameUSen = bugItem.Name.NameUSen,
                    NameEUen = bugItem.Name.NameEUen,
                    NameEUde = bugItem.Name.NameEUde,
                    NameEUes = bugItem.Name.NameEUes
                    
                },
                Availability = new Availability
                {
                    Monthnorthern = bugItem.Availability.Monthnorthern,
                    Monthsouthern = bugItem.Availability.Monthsouthern,
                    Time = bugItem.Availability.Time,
                    IsAllDay = bugItem.Availability.IsAllDay,
                    IsAllYear = bugItem.Availability.IsAllYear,
                    Location = bugItem.Availability.Location,
                    Rarity = bugItem.Availability.Rarity,
                    Montharraynorthern = bugItem.Availability.Montharraynorthern,
                    Montharraysouthern = bugItem.Availability.Montharraysouthern,
                    Timearray = bugItem.Availability.Timearray
                },
                Price = bugItem.Price,
                Priceflick = bugItem.Priceflick,
                Catchphrase = bugItem.Catchphrase,
                Museumphrase = bugItem.Museumphrase,
                Icon_uri = bugItem.Icon_uri,
                Image_uri = bugItem.Image_uri
            };
    }
}
