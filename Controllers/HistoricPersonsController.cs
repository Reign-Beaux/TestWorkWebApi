using AutoMapper;
using BackendTestWork.Entities;
using BackendTestWork.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BackendTestWork.Controllers
{
    [ApiController]
    [Route("api/historic_persons")]
    public class HistoricPersonsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly SPHistoricPerson sp;

        public HistoricPersonsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.sp = new SPHistoricPerson();
        }

        [HttpGet("{personId:int}")]
        public async Task<ActionResult<List<HistoricPerson>>> Get(int personId)
            => await sp.GetHistoric(personId);

        [HttpPut("{id:int}")]
        public void Put(int id)
            => sp.RestorePerson(id);
    }
}
