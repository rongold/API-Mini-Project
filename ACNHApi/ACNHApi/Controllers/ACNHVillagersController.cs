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
    [Route("api/ACNHVillagers")]
    [ApiController]
    public class ACNHVillagersController : ControllerBase
    {
        private readonly ACNHContext _context;

        public ACNHVillagersController(ACNHContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillagerResponseTDO>>> GetACNHItems()
        {
            return await _context.VillagerItems
                .Select(x => ACNHItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VillagerResponseTDO>> GetTodoItem(int id)
        {
            var todoItem = await _context.VillagerItems.Include(i=>i.Name).Include(i=>i.Catchtranslations).Where(i=>i.Id==id).FirstOrDefaultAsync();

            if (todoItem == null)
            {
                return NotFound();
            }

            return ACNHItemToDTO(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, VillagerResponseTDO acnhItemDTO)
        {
            if (id != acnhItemDTO.Id)
            {
                return BadRequest();
            }

            var todoItem = await _context.VillagerItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Filename = acnhItemDTO.Filename;
            todoItem.Name = new Models.Name
            {
                NameUSen = acnhItemDTO.Name.NameUSen,
                NameEUen = acnhItemDTO.Name.NameEUen,
                NameEUde = acnhItemDTO.Name.NameEUde,
                NameEUes = acnhItemDTO.Name.NameEUes,
                
            };
            todoItem.Personality = acnhItemDTO.Personality;
            todoItem.Birthday = acnhItemDTO.Birthday;
            todoItem.Birthdaystring = acnhItemDTO.Birthdaystring;
            todoItem.Species = acnhItemDTO.Species;
            todoItem.Gender = acnhItemDTO.Gender;
            todoItem.Subtype = acnhItemDTO.Subtype;
            todoItem.Hobby = acnhItemDTO.Hobby;
            todoItem.Catchphrase = acnhItemDTO.Catchphrase;
            todoItem.Icon_uri = acnhItemDTO.Icon_uri;
            todoItem.Image_uri = acnhItemDTO.Image_uri;
            todoItem.Bubblecolor = acnhItemDTO.Bubblecolor;
            todoItem.Textcolor = acnhItemDTO.Textcolor;
            todoItem.Saying = acnhItemDTO.Saying;
            todoItem.Catchtranslations = new Models.CatchTranslations
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
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<VillagerResponseTDO>> CreateTodoItem(VillagerResponseTDO acnhVillagerDTO)
        {
            var villagerItem = new VillagerResponse
            {
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
                nameof(GetTodoItem),
                new { id = villagerItem.Id },
                ACNHItemToDTO(villagerItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _context.VillagerItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.VillagerItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long id) =>
             _context.VillagerItems.Any(e => e.Id == id);

        private static VillagerResponseTDO ACNHItemToDTO(VillagerResponse villagerItem) =>
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
