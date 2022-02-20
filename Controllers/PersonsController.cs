using AutoMapper;
using BackendTestWork.DTOs;
using BackendTestWork.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendTestWork.Helpers;

namespace BackendTestWork.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly StoreProcedures sp;

        public PersonsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.sp = new StoreProcedures();
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> Get()
            => await sp.GetPersons();

        [HttpGet("{id:int}", Name = "getPerson")]
        public async Task<ActionResult<PersonDTO>> Get(int id)
        {
            var entity = await sp.FindPerson(id);
            if (entity.Value.Id == 0)
                return NotFound();

            return entity;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePersonDTO createPersonDTO)
        {
            var entity = mapper.Map<Person>(createPersonDTO);
            context.Add(entity);
            await context.SaveChangesAsync();
            var personDTO = mapper.Map<PersonDTO>(entity);

            return new CreatedAtRouteResult("getPerson", new { id = personDTO.Id }, personDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreatePersonDTO createPersonDTO)
        {
            var entity = mapper.Map<Person>(createPersonDTO);
            entity.Id = id;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var present = await context.Persons.AnyAsync(x => x.Id == id);
            if (!present)
                return NotFound();

            context.Remove(new Person() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("factorial")]
        public ActionResult Factorial([FromQuery] int baseFactorial)
        {
            Exercises exercise = new Exercises();
            return Ok(new 
            {
                result = exercise.RunFactorial(baseFactorial)
            });
        }

        [HttpGet("potencia")]
        public ActionResult Potencia([FromQuery] int x, int y)
        {
            Exercises exercise = new Exercises();
            return Ok(new
            {
                result = exercise.RunPotencia(x, y)
            });
        }
    }
}
