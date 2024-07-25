using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonTransaction.BusinessLayer.Abstract;
using PersonTransaction.DtoLayer.PersonDto;
using PersonTransaction.EntityLayer.Entities;

namespace PersonTransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult PersonList()
        {
            var values = _mapper.Map<List<ResultPersonDto>>(_personService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreatePerson(CreatePersonDto createPersonDto)
        {
            _personService.TAdd(new Person()
            {
                Name = createPersonDto.Name
            });
            return Ok("Person Added.");
        }
        [HttpDelete]
        public IActionResult DeletePerson(int id)
        {
            var value = _personService.TGetByID(id);
            _personService.TDelete(value);
            return Ok("Person Deleted");

        }
        [HttpGet("GetPerson")]
        public IActionResult GetPerson(int id)
        {
            var value = _personService.TGetByID(id);
            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            _personService.TUpdate(new Person()
            {
                PersonID=updatePersonDto.PersonID,
                Name = updatePersonDto.Name
            });
            return Ok("Person Updated.");
        }
    }
}
