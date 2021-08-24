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
        public async Task<ActionResult<IEnumerable<ACNHItemTDO>>> GetACNHItems()
        {
            return await _context.ACNHVillagerItems
                .Select(x => ACNHItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ACNHItemTDO>> GetTodoItem(long id)
        {
            var todoItem = await _context.ACNHVillagerItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ACNHItemToDTO(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, ACNHItemTDO.VillagerResponse acnhItemDTO)
        {
            if (id != acnhItemDTO.Id)
            {
                return BadRequest();
            }

            var todoItem = await _context.ACNHVillagerItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            
            todoItem.Name = acnhItemDTO.Name;
            todoItem.IsComplete = acnhItemDTO.IsComplete;

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
        public async Task<ActionResult<ACNHItemTDO>> CreateTodoItem(ACNHItemTDO acnhItemDTO)
        {
            var acnhItem = new ACNHItem
            {
                IsComplete = acnhItemDTO.IsComplete,
                Name = acnhItemDTO.Name
            };

            _context.ACNHVillagerItems.Add(acnhItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = acnhItem.Id },
                ACNHItemToDTO(acnhItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.ACNHVillagerItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.ACNHVillagerItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long id) =>
             _context.ACNHVillagerItems.Any(e => e.Id == id);

        private static ACNHItemTDO ACNHItemToDTO(ACNHItem todoItem) =>
            new ACNHItemTDO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}
