using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVet.Web.Data;
using MyVet.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PetTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public PetTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PetTypes
        [HttpGet]
        public IEnumerable<PetType> GetPetTypes()
        {
            return _context.PetTypes;
        }

        // GET: api/PetTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var petType = await _context.PetTypes.FindAsync(id);

            if (petType == null)
            {
                return NotFound();
            }

            return Ok(petType);
        }

        // PUT: api/PetTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetType([FromRoute] int id, [FromBody] PetType petType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petType.Id)
            {
                return BadRequest();
            }

            _context.Entry(petType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PetTypes
        [HttpPost]
        public async Task<IActionResult> PostPetType([FromBody] PetType petType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PetTypes.Add(petType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetType", new { id = petType.Id }, petType);
        }

        // DELETE: api/PetTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var petType = await _context.PetTypes.FindAsync(id);
            if (petType == null)
            {
                return NotFound();
            }

            _context.PetTypes.Remove(petType);
            await _context.SaveChangesAsync();

            return Ok(petType);
        }

        private bool PetTypeExists(int id)
        {
            return _context.PetTypes.Any(e => e.Id == id);
        }
    }
}