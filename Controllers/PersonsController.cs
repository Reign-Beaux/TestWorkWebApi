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
            => await sp.GetPersons("PersonsAll");

        [HttpGet("{id:int}", Name = "getPerson")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var entity = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return NotFound();

            var dto = mapper.Map<Person>(entity);
            return dto;
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
            //var result = RunFactorial(baseFactorial);
            return Ok(new 
            {
                results = 15
            });
        }

        //public int RunFactorial(int n)
        //{
        //    if (n == 0)
        //        n = 1;
        //    else
        //        n *= RunFactorial(n - 1);

        //    return n;
        //}
    }
}
