using AutoMapper;
using BackendTestWork.DTOs;
using BackendTestWork.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackendTestWork.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PersonsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> Get()
        {
            var entities = await context.Persons.ToListAsync();
            var dtos = mapper.Map<List<PersonDTO>>(entities);
            return dtos;
        }

        [HttpGet("{id:int}", Name = "getPerson")]
        public async Task<ActionResult<PersonDTO>> Get(int id)
        {
            var entity = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return NotFound();

            var dto = mapper.Map<PersonDTO>(entity);
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

        //[HttpGet("{nombre}")]
        //public async Task<ActionResult> Get(string nombre)
        //{
        //    var person = context.Persons.Where(p => p.Nombre == nombre)
        //                                .Select(x => new { x.Nombre, x.FechaNacimiento })
        //                                .FirstOrDefault();
        //}
    }
}
