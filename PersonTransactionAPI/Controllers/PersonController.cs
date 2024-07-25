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
        [HttpGet("GetAllPerson")]
        public IActionResult PersonList()
        {
            var values = _mapper.Map<List<ResultPersonDto>>(_personService.TGetListAll());
            return Ok(values);
        }
        [HttpPost("CreatePerson")]
        public IActionResult CreatePerson(CreatePersonDto createPersonDto)
        {
            _personService.TAdd(new Person()
            {
                TCKimlik=createPersonDto.TCKimlik,
                Name = createPersonDto.Name
            });
            return Ok("Person Added.");
        }
        [HttpDelete("DeletePerson")]
        public IActionResult DeletePerson(string tcKimlik)
        {
            var person = _personService.GetPersonByTCKimlik(tcKimlik);
            if (person == null)
            {
                return NotFound("Person not found.");
            }

            _personService.TDelete(person);
            return Ok("Person Deleted");
        }

        [HttpGet("GetPersonByTCKimlik")]
        public IActionResult GetPersonByTCKimlik(string tcKimlik)
        {
            var person = _personService.GetPersonByTCKimlik(tcKimlik);
            if (person != null)
            {
                var result = _mapper.Map<ResultPersonDto>(person);
                return Ok(result);
            }
            else
            {
                return NotFound("Person not found.");
            }
        }

        [HttpPut("UpdatePerson")]
        public IActionResult Uppp(UpdatePersonDto updatePersonDto)
        {
            try
            {
                _personService.UpdatePersonByTCKimlik(updatePersonDto.TCKimlik, new Person()
                {
                    Name = updatePersonDto.Name,
                    TCKimlik = updatePersonDto.TCKimlik
                });
                return Ok("Person Updated.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
