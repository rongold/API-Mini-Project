using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACNHApi.Models;

namespace ACNHApi.Controllers
{
    [Route("api/ACNHFish")]
    [ApiController]
    public class ACNHFishController : ControllerBase
    {
        private readonly ACNHContext _context;

        public ACNHFishController(ACNHContext context)
        {
            _context = context;
        }

        // GET: api/FishItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FishResponseTDO>>> GetACNHFishItems()
        {
            return await _context.FishItems.Include(f => f.Name).Include(f => f.Availability)
                .Select(x => FishItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FishResponseTDO>> GetFishItem(long id)
        {
            var todoItem = await _context.FishItems.Include(f => f.Name).Include(f => f.Availability)
                .Where(i => i.Id == id).FirstOrDefaultAsync();

            if (todoItem == null)
            {
                return NotFound();
            }

            return FishItemToDTO(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFishItem(long id, FishResponseTDO acnhItemDTO)
        {
            if (id != acnhItemDTO.Id)
            {
                return BadRequest();
            }

            var fishItem = await _context.FishItems.Include(f => f.Name).Include(f => f.Availability)
                .Where(i => i.Id == id).FirstOrDefaultAsync();
            
            if (fishItem == null)
            {
                return NotFound();
            }
            fishItem.Filename = acnhItemDTO.Filename;
            fishItem.Name = new Models.Name
            {
                NameUSen = acnhItemDTO.Name.NameUSen,
                NameEUen = acnhItemDTO.Name.NameEUen,
                NameEUde = acnhItemDTO.Name.NameEUde,
                NameEUes = acnhItemDTO.Name.NameEUes,

            };
            fishItem.Availability = new Models.Availability()
            {
                Monthnorthern = acnhItemDTO.Availability.Monthnorthern,
                Monthsouthern = acnhItemDTO.Availability.Monthsouthern,
                Time = acnhItemDTO.Availability.Time,
                IsAllDay = acnhItemDTO.Availability.IsAllDay,
                IsAllYear = acnhItemDTO.Availability.IsAllDay,
                Location = acnhItemDTO.Availability.Location,
                Rarity = acnhItemDTO.Availability.Rarity,
                Montharraynorthern = acnhItemDTO.Availability.Montharraynorthern,
                Montharraysouthern = acnhItemDTO.Availability.Montharraysouthern,
                Timearray = acnhItemDTO.Availability.Timearray
            };
            fishItem.Shadow = acnhItemDTO.Shadow;
            fishItem.Price = acnhItemDTO.Price;
            fishItem.Pricecj = acnhItemDTO.Pricecj;
            fishItem.Catchphrase = acnhItemDTO.Catchphrase;
            fishItem.Museumphrase = acnhItemDTO.Museumphrase;
            fishItem.Image_uri = acnhItemDTO.Image_uri;
            fishItem.Icon_uri = acnhItemDTO.Icon_uri;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FishItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<FishResponseTDO>> CreateFishItem(FishResponseTDO acnhItemDTO)
        {
            var acnhItem = new FishResponse
            {
                Id = acnhItemDTO.Id,
                Filename = acnhItemDTO.Filename,
                //Name is Empty
                Name = new Models.Name
                {
                    NameUSen = acnhItemDTO.Name.NameUSen,
                    NameEUen = acnhItemDTO.Name.NameEUen,
                    NameEUde = acnhItemDTO.Name.NameEUde,
                    NameEUes = acnhItemDTO.Name.NameEUes,

                },
                Availability = new Models.Availability()
                {
                    Monthnorthern = acnhItemDTO.Availability.Monthnorthern,
                    Monthsouthern = acnhItemDTO.Availability.Monthsouthern,
                    Time = acnhItemDTO.Availability.Time,
                    IsAllDay = acnhItemDTO.Availability.IsAllDay,
                    IsAllYear = acnhItemDTO.Availability.IsAllDay,
                    Location = acnhItemDTO.Availability.Location,
                    Rarity = acnhItemDTO.Availability.Rarity,
                    Montharraynorthern = acnhItemDTO.Availability.Montharraynorthern,
                    Montharraysouthern = acnhItemDTO.Availability.Montharraysouthern,
                    Timearray = acnhItemDTO.Availability.Timearray
                },
                Shadow = acnhItemDTO.Shadow,
                Price = acnhItemDTO.Price,
                Pricecj = acnhItemDTO.Pricecj,
                Catchphrase = acnhItemDTO.Catchphrase,
                Museumphrase = acnhItemDTO.Museumphrase,
                Image_uri = acnhItemDTO.Image_uri,
                Icon_uri = acnhItemDTO.Icon_uri

            };

            _context.FishItems.Add(acnhItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetFishItem),
                new { id = acnhItem.Id },
                FishItemToDTO(acnhItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFishItem(long id)
        {
            var fishItem = await _context.FishItems.Include(f => f.Name).Include(f => f.Availability)
                .Where(i => i.Id == id).FirstOrDefaultAsync();

            if (fishItem == null)
            {
                return NotFound();
            }

            _context.FishItems.Remove(fishItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FishItemExists(long id) =>
             _context.FishItems.Any(e => e.Id == id);

        private static FishResponseTDO FishItemToDTO(FishResponse fishItem) =>
            new FishResponseTDO
            {
                Id = fishItem.Id,
                Filename = fishItem.Filename,
                Name = new Name
                {
                    NameUSen = fishItem.Name.NameUSen,
                    NameEUen = fishItem.Name.NameEUen,
                    NameEUde = fishItem.Name.NameEUde,
                    NameEUes = fishItem.Name.NameEUes,
                },
                Availability = new Availability()
                {
                    Monthnorthern = fishItem.Availability.Monthnorthern,
                    Monthsouthern = fishItem.Availability.Monthsouthern,
                    Time = fishItem.Availability.Time,
                    IsAllDay = fishItem.Availability.IsAllDay,
                    IsAllYear = fishItem.Availability.IsAllDay,
                    Location = fishItem.Availability.Location,
                    Rarity = fishItem.Availability.Rarity,
                    Montharraynorthern = fishItem.Availability.Montharraynorthern,
                    Montharraysouthern = fishItem.Availability.Montharraysouthern,
                    Timearray = fishItem.Availability.Timearray
                },
                Shadow = fishItem.Shadow,
                Price = fishItem.Price,
                Pricecj = fishItem.Pricecj,
                Catchphrase = fishItem.Catchphrase,
                Museumphrase = fishItem.Museumphrase,
                Image_uri = fishItem.Image_uri,
                Icon_uri = fishItem.Icon_uri

            };
    }
}
