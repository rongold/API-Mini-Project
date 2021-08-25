using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACNHApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACNHApi.Controllers
{
	[Route("api/ACNHVillagers")]
    [ApiController]
    public class ACNHVillagersController : ControllerBase
    {
        private readonly ACNHContext _context;

        public ACNHVillagersController(ACNHContext context)
        {
            _context = context;
        }

        // GET: api/VillagerItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillagerResponseTDO>>> GetVillagerItems()
        {
            return await _context.VillagerItems.Include(i=>i.Name).Include(i=>i.Catchtranslations)
                .Select(x => VillagerItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VillagerResponseTDO>> GetVillagerItem(int id)
        {
            var villagerItem = await _context.VillagerItems.Include(i=>i.Name).Include(i=>i.Catchtranslations).Where(i=>i.Id==id).FirstOrDefaultAsync();
            object response =  "Villager not found" ;
            if (villagerItem == null)
            {
                return NotFound(response.ToString());
            }

            return VillagerItemToDTO(villagerItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVillagerItem(int id, VillagerResponseTDO acnhItemDTO)
        {
            if (id != acnhItemDTO.Id)
            {
                return BadRequest();
            }

            var villagerItem = await _context.VillagerItems.Include(i => i.Name).Include(i => i.Catchtranslations).Where(i => i.Id == id).FirstOrDefaultAsync();
            if (villagerItem == null)
            {
                return NotFound();
            }

            villagerItem.Filename = acnhItemDTO.Filename;
            villagerItem.Name = new Models.Name
            {
                NameUSen = acnhItemDTO.Name.NameUSen,
                NameEUen = acnhItemDTO.Name.NameEUen,
                NameEUde = acnhItemDTO.Name.NameEUde,
                NameEUes = acnhItemDTO.Name.NameEUes,
                
            };
            villagerItem.Personality = acnhItemDTO.Personality;
            villagerItem.Birthday = acnhItemDTO.Birthday;
            villagerItem.Birthdaystring = acnhItemDTO.Birthdaystring;
            villagerItem.Species = acnhItemDTO.Species;
            villagerItem.Gender = acnhItemDTO.Gender;
            villagerItem.Subtype = acnhItemDTO.Subtype;
            villagerItem.Hobby = acnhItemDTO.Hobby;
            villagerItem.Catchphrase = acnhItemDTO.Catchphrase;
            villagerItem.Icon_uri = acnhItemDTO.Icon_uri;
            villagerItem.Image_uri = acnhItemDTO.Image_uri;
            villagerItem.Bubblecolor = acnhItemDTO.Bubblecolor;
            villagerItem.Textcolor = acnhItemDTO.Textcolor;
            villagerItem.Saying = acnhItemDTO.Saying;
            villagerItem.Catchtranslations = new Models.CatchTranslations
            {
                CatchUSen = acnhItemDTO.Catchtranslations.CatchUSen,
                CatchEUen = acnhItemDTO.Catchtranslations.CatchUSen,
                CatchEUde = acnhItemDTO.Catchtranslations.CatchUSen,
                CatchEUes = acnhItemDTO.Catchtranslations.CatchUSen,
                
            };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!VillagerItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<VillagerResponseTDO>> CreateVillagerItem(VillagerResponseTDO acnhVillagerDTO)
        {
            var villagerItem = new VillagerResponse
            {
                Id = acnhVillagerDTO.Id,
                Filename = acnhVillagerDTO.Filename,
                Name = new Models.Name
                {
                    NameUSen = acnhVillagerDTO.Name.NameUSen,
                    NameEUen = acnhVillagerDTO.Name.NameEUen,
                    NameEUde = acnhVillagerDTO.Name.NameEUde,
                    NameEUes = acnhVillagerDTO.Name.NameEUes,
                    
                },
                Personality = acnhVillagerDTO.Personality,
                Birthday = acnhVillagerDTO.Birthday,
                Birthdaystring = acnhVillagerDTO.Birthdaystring,
                Species = acnhVillagerDTO.Species,
                Gender = acnhVillagerDTO.Gender,
                Subtype = acnhVillagerDTO.Subtype,
                Hobby = acnhVillagerDTO.Hobby,
                Catchphrase = acnhVillagerDTO.Catchphrase,
                Icon_uri = acnhVillagerDTO.Icon_uri,
                Image_uri = acnhVillagerDTO.Image_uri,
                Bubblecolor = acnhVillagerDTO.Bubblecolor,
                Textcolor = acnhVillagerDTO.Textcolor,
                Saying = acnhVillagerDTO.Saying,
                Catchtranslations = new Models.CatchTranslations
                {
                    CatchUSen = acnhVillagerDTO.Catchtranslations.CatchUSen,
                    CatchEUen = acnhVillagerDTO.Catchtranslations.CatchUSen,
                    CatchEUde = acnhVillagerDTO.Catchtranslations.CatchUSen,
                    CatchEUes = acnhVillagerDTO.Catchtranslations.CatchUSen,
                    
                }
            };

            _context.VillagerItems.Add(villagerItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetVillagerItem),
                new { id = villagerItem.Id },
                VillagerItemToDTO(villagerItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVillagerItem(int id)
        {
            var villagerItem = await _context.VillagerItems.Include(i => i.Name).Include(i => i.Catchtranslations).Where(i => i.Id == id).FirstOrDefaultAsync();

            if (villagerItem == null)
            {
                return NotFound();
            }

            _context.VillagerItems.Remove(villagerItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VillagerItemExists(long id) =>
             _context.BugItems.Any(e => e.Id == id);

        private static VillagerResponseTDO VillagerItemToDTO(VillagerResponse villagerItem) =>
            new VillagerResponseTDO
            {
                Id = villagerItem.Id,
                Filename = villagerItem.Filename,
                Name = new Name
                {
                    NameUSen = villagerItem.Name.NameUSen,
                    NameEUen = villagerItem.Name.NameEUen,
                    NameEUde = villagerItem.Name.NameEUde,
                    NameEUes = villagerItem.Name.NameEUes
                    
                },
                Personality = villagerItem.Personality,
                Birthday = villagerItem.Birthday,
                Birthdaystring = villagerItem.Birthdaystring,
                Species = villagerItem.Species,
                Gender = villagerItem.Gender,
                Subtype = villagerItem.Subtype,
                Hobby = villagerItem.Hobby,
                Catchphrase = villagerItem.Catchphrase,
                Icon_uri = villagerItem.Icon_uri,
                Image_uri = villagerItem.Image_uri,
                Bubblecolor = villagerItem.Bubblecolor,
                Textcolor = villagerItem.Textcolor,
                Saying = villagerItem.Saying,
                Catchtranslations = new CatchTranslations
                {
                    CatchUSen = villagerItem.Catchtranslations.CatchUSen,
                    CatchEUen = villagerItem.Catchtranslations.CatchEUen,
                    CatchEUde = villagerItem.Catchtranslations.CatchEUde,
                    CatchEUes = villagerItem.Catchtranslations.CatchEUes
                    
                }
            };
    }
}
