using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Application.DbContexts;
using Api.Application.Models;
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract


namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        #region HttpGet

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            if (_dbContext.Persons == null)
            {
                return NotFound();
            }
            return await _dbContext.Persons.ToListAsync();
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            if (_dbContext.Persons == null)
            {
                return NotFound();
            }
            var person = await _dbContext.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }


        #endregion

        #region HttpPost

        // POST: api/Person
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            if (_dbContext.Persons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Persons'  is null.");
            }
            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }


        #endregion

        #region HttpPut

        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(Guid id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(person).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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



        #endregion

        #region HttpDelete

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            if (_dbContext.Persons == null)
            {
                return NotFound();
            }
            var person = await _dbContext.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


        #endregion



        #region Helper

        private bool PersonExists(Guid id)
        {
            return _dbContext.Persons == null || (_dbContext.Persons.Any(e => e.Id == id));
        }

        #endregion

    }
}
