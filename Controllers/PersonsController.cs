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
        public void Post([FromBody] PersonDTO createPerson)
            => sp.CreatePerson(createPerson);

        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] PersonDTO createPersonDTO)
            => sp.UpdatePerson(id, createPersonDTO);

        [HttpDelete("{id:int}")]
        public void Delete(int id)
            => sp.DeletePerson(id);

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

        [HttpGet("filtroNombre")]
        public async Task<ActionResult<List<PersonDTO>>> Get([FromQuery] string Nombre)
            => await sp.SearchNombrePerson(Nombre);
    }
}
